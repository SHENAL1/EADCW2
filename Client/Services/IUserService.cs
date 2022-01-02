using CW2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.Client.Services
{
    public interface IUserService
    {
        event Action OnChange;
        List<User> Users { get; set; }

        Task<List<User>> GetUsers();

        Task<User> GetSingleUser(int id);

        Task<List<User>> CreateUser(User user);

        Task<List<User>> UpdateUser(User user, int id);
    }
}
