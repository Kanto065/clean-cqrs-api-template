using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        IRepositoryAsync<User> User { get; }
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTranscationAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
