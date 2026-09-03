using GamingCommunity.Domain.Entities.Users;
using GamingCommunity.Persistence;
using GamingCommunity.Persistence.Contexts;
using GamingCommunity.Application;
using GamingCommunity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GamingCommunity.Persistence.Seed;
using Microsoft.OpenApi.Models;
using GamingCommunity.API.Services;
using GamingCommunity.Application.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);



//Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));


//Sonradan deyisecek muveqqeti
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService,CurrentUserService>();
//Sonradan deyisecek muveqqeti


//Identity Configuration
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    //identity options configleri
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders()
.AddRoles<IdentityRole<Guid>>();


//Dependency Injections
builder.Services.AddPersistence();
builder.Services.AddApplicationServices();
builder.Services.AddJwtAuthentication(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Swagger Authorize Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();


//Role seeder
using (var scope = app.Services.CreateScope())
{
    var roleManager =
        scope.ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole<Guid>>>();

    await RoleSeeder.SeedRole(roleManager);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
