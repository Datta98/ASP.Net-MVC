using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithDependency.Models
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmailId { get; set; }
    }
}