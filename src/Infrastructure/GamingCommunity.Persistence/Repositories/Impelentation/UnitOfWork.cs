using GamingCommunity.Persistence.Contexts;
using GamingCommunity.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Persistence.Repositories.Impelentation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IDbContextTransaction? _transaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction is not null)
            {
                throw new InvalidOperationException("A transaction is already active.");
            }

            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction is null)
            {
                throw new InvalidOperationException(
                    "There is no active transaction to commit.");
            }

            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction is null)
            {
                return;
            }

            try
            {
                await _transaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                await _context.DisposeAsync();
                _transaction = null;
            }
        }

        
    }
}
