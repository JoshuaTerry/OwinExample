using Microsoft.AspNet.Identity;
using OwinExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinExample.Services
{
    public class RoleService : IRoleStore<Role, int>, IQueryableRoleStore<Role, int>
    {
        private List<Role> roles = new List<Role>();
        public RoleService()
        {
            roles.Add(new Role { Id = 1, Name = "Admin" });
            roles.Add(new Role { Id = 2, Name = "General" });
            roles.Add(new Role { Id = 3, Name = "Exclusive" });
        }
        public IQueryable<Role> Roles => roles.AsQueryable();

        public Task CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        { 
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            return Task.FromResult<Role>(roles.FirstOrDefault(r => r.Id == roleId));
        } 

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Task.FromResult<Role>(roles.FirstOrDefault(r => r.Name == roleName));
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}