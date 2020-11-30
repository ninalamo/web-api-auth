using basic_auth_api.Entities;
using basic_auth_api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basic_auth_api.Services
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" },
            new User { Id = 2, FirstName = "Nin", LastName = "Alamo", Username = "ninalamo", Password = "Love2eat!" },
            new User { Id = 3, FirstName = "User", LastName = "One", Username = "user1", Password = Guid.NewGuid().ToString() },
            new User { Id = 4, FirstName = "User", LastName = "Two", Username = "user2", Password = Guid.NewGuid().ToString() },
            new User { Id = 5, FirstName = "User", LastName = "Three", Username = "user3", Password = Guid.NewGuid().ToString() },
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users.WithoutPasswords());
        }
    }
}
