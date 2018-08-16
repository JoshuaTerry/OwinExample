using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OwinExample.Models;
using OwinExample.Services;
using System;
using System.Threading.Tasks;

namespace OwinExample.App_Start
{
    public class UserManager : UserManager<User, int> //, IUserManager
    {
        public UserManager(IUserStore<User, int> store)
            : base(store)
        {
        }
        private UserService userService = new UserService();
        public UserManager() : base(new UserService())
        { 
        }
        public override Task<User> FindAsync(string userName, string password)
        {
            return userService.FindByNameAsync(userName);
            //return base.FindAsync(userName, password);
        }
        public override async Task<User> FindByIdAsync(int userId)
        {
            var user = await Store.FindByIdAsync(userId);
            return user;
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager();
            // Configure validation logic for usernames 
            //manager.UserValidator = new UserValidator<User, int>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = false
            //};
            //// Configure validation logic for passwords 
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            //};
             
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}