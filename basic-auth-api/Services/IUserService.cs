using basic_auth_api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basic_auth_api.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
