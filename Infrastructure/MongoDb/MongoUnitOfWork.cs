using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace Infrastructure.MongoDb
{
    public class MongoUnitOfWork : IMongoUnitOfWork
    {
        public IMongoRepository<User> User { get; }
        public MongoUnitOfWork(IMongoRepository<User> userRepo)
        {
            User = userRepo;
        }
    }
}
