using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task Insert(User user);
        Task<ICollection<User>> GetAll();
        Task Delete(string id);
        Task Update(string id, User user);
        Task<User> GetById(string id);
    }
}
