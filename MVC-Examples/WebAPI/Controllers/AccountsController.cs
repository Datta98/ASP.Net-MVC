using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebAPI.Models;
using System.Web.Http.Filters;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    
    public class AccountsController : ApiController
    {
        //  Repositories.IUserRepository userRepository = new Repositories.UserSQLRepository();

        private IUserRepository userRepository = null;
        public AccountsController(IUserRepository user)
        {
            userRepository = user;
        }


        public string Validate(Boolean isValid)
        {
            if (isValid)
            {
                return "Sucessfully ";
            }
            else
            {
                return " Failed";
            }
        }

        [HttpPost]
        public string AddUser([FromBody]AccountsUser _usm)
        {
            Boolean isSucess = userRepository.AddUser(_usm);
            string msg = Validate(isSucess);
            return "Added "+msg;
        }

        [HttpPut]
        public string UpdateUser([FromBody] AccountsUser _usm)
        {
            Boolean isupdate = userRepository.UpdateUser(_usm);
            string msg = Validate(isupdate);
            return "Updated "+msg;
        }

        [HttpDelete]
        public string DeleteUser(string name)
        {
            Boolean isdeleted = userRepository.DeleteUser(name);
            string msg=  Validate(isdeleted);
            return "Deleted "+msg;
        }


       
        [HttpGet]
        public IEnumerable<AccountsUser> GetAllUser()
        {
            IEnumerable<AccountsUser> users = userRepository.GetallUsers();
            return users;
        }

        public AccountsUser GetUserByName(string name)
        {
            return userRepository.GetallUsers().Where(user => user.UserName == name).FirstOrDefault();
        }


    }
}

