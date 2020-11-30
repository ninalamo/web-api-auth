using basic_auth_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basic_auth_api.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users) => users.Select(x => x.WithoutPassword());

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }

}
