using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Contracts;
using Domain.Entities;

namespace Application.MongoServices
{
    public class UserService : IUserService
    {
        private readonly IMongoUnitOfWork _mongoUnitOfWork;
        public UserService(IMongoUnitOfWork mongoUnitOfWork)
        {
            _mongoUnitOfWork = mongoUnitOfWork;
        }

        public async Task Insert(User user)
        {
            await _mongoUnitOfWork.User.AddAsync(user);
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _mongoUnitOfWork.User.GetAllAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _mongoUnitOfWork.User.GetByIdAsync(id);
        }

        public async Task Update(string id, User user)
        {
            await _mongoUnitOfWork.User.UpdateAsync(id, user);
        }

        public async Task Delete(string id)
        {
            await _mongoUnitOfWork.User.DeleteAsync(id);
        }



    }
}
