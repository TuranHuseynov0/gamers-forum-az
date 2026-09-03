using GamingCommunity.Application.DTOs.Requests.Auth;
using GamingCommunity.Application.DTOs.Responses.ApiResponse;
using GamingCommunity.Application.DTOs.Responses.Auth;
using GamingCommunity.Application.Services.Interfaces;
using GamingCommunity.Domain.Entities.Users;
using GamingCommunity.Persistence.Repositories.Interface;
using Microsoft.AspNetCore.Identity;

namespace GamingCommunity.Application.Services.Implementations
{
    public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtTokenService jwtTokenService, IUnitOfWork unitOfWork) : IAuthService
    {
        public async Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email.Trim());

            if(user is null)
                return ApiResponse<AuthResponse>.FailResponse("Invalid email or password", 401);

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
            if (!signInResult.Succeeded)
            {
                return ApiResponse<AuthResponse>.FailResponse(
                    "Invalid email or password.",
                    401);
            }

            var accessToken = await jwtTokenService.GenerateTokenAsync(user);

            var authResponse = new AuthResponse
            {
                AccessToken = accessToken
            };

            return ApiResponse<AuthResponse>.SuccessResponse(authResponse, "Login successful", 200);
        }

        public async Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await userManager.FindByEmailAsync(request.Email.Trim());

            if (existingUser is not null)
            {
                return ApiResponse<AuthResponse>.FailResponse("This user already exists!", 409);
            }

            await unitOfWork.BeginTransactionAsync();

            try
            {
                var newUser = new AppUser
                {
                    UserName = request.Username.Trim(),
                    Email = request.Email.Trim(),
                    CreatedAtUtc = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(newUser, request.Password);

                if(!result.Succeeded)
                {
                    await unitOfWork.RollbackTransactionAsync();

                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return ApiResponse<AuthResponse>.FailResponse($"User registration failed: {errors}", 400);
                }

                var roleResult = await userManager.AddToRoleAsync(newUser, "User");

                if(!roleResult.Succeeded)
                {
                    await unitOfWork.RollbackTransactionAsync();

                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    return ApiResponse<AuthResponse>.FailResponse($"Assigning role failed: {errors}", 400);
                }

                var accessToken = await jwtTokenService.GenerateTokenAsync(newUser);

                var authResponse = new AuthResponse
                {
                    UserId = newUser.Id,
                    Username = newUser.UserName ?? string.Empty,
                    Email = newUser.Email ?? string.Empty,
                    AccessToken = accessToken
                };

                await unitOfWork.CommitTransactionAsync();

                return ApiResponse<AuthResponse>.SuccessResponse(authResponse, "Registration successful", 201);
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();

                return ApiResponse<AuthResponse>.FailResponse("An error occurred during registration.", 500);
            }
        }
    }
}
