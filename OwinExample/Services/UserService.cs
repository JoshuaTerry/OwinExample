using Microsoft.AspNet.Identity;
using OwinExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OwinExample.Services
{
    public class UserService : IUserStore<User, int>,
                                IUserRoleStore<User, int>,
                                IUserEmailStore<User, int>,
                                IUserPasswordStore<User, int>,
                                IQueryableUserStore<User, int>
    {
        private List<User> users = new List<User>();
        private List<(User, IList<string>)> rolesByUser = new List<(User, IList<string>)>();

        public UserService()
        {
            var user = new User { Id = 1, UserName = "bob" };
            users.Add(user);
            rolesByUser.Add((user, new string[] { "Admin", "General" }.ToList()));
        }
        public IQueryable<User> Users => users.AsQueryable();

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
             
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int userId) => Task.FromResult<User>(users.FirstOrDefault(u => u.Id == userId));

        public Task<User> FindByNameAsync(string userName) => Task.FromResult<User>(users.FirstOrDefault(u => u.UserName == userName));

        public Task<string> GetEmailAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            var userRoles = rolesByUser.FirstOrDefault(ur => ur.Item1 == user);
            return Task.FromResult<IList<string>>(userRoles.Item1 == null ? new List<string>() : userRoles.Item2);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            var userRoles = rolesByUser.FirstOrDefault(ur => ur.Item1 == user);
            return Task.FromResult<bool>(userRoles.Item1 == null ? false : userRoles.Item2.Contains(roleName));
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        private void CheckUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User");
            }
        }
    }
}