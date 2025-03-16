using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface IMongoUnitOfWork
    {
        IMongoRepository<User> User { get; }
    }
}
