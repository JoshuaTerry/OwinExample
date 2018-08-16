using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OwinExample.Models;
using OwinExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace OwinExample.App_Start
{
    public class RoleManager : RoleManager<Role, int>
    {
        public RoleManager() : base(new RoleService()) { }

        public static RoleManager Create(IdentityFactoryOptions<RoleManager> options, IOwinContext context)
        { 
            return new RoleManager();
        }
    }
}