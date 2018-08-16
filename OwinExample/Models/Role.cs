using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwinExample.Models
{
    public class Role : IRole<int>
    {
        public int Id { get; set; }

        public string Name
        {
            get; set;
        }
    }
}