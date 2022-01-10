using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWithDependency.Models;

namespace WebApiWithDependency.Controllers
{
    public class AccountsController : ApiController
    {
          Repositories.UserSQLRepository userRepository = new Repositories.UserSQLRepository();

        //private IUserRepository userRepository = null;
        //public AccountsController(IUserRepository user)
        //{
        //    userRepository = user;
        //}
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
        public string AddUser([FromBody]UserModel _usm)
        {
            Boolean isSucess = userRepository.AddUser(_usm);
            string msg = Validate(isSucess);
            return "Added "+msg;
        }

        [HttpPut]
        public string UpdateUser([FromBody] UserModel _usm)
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
        public IEnumerable<UserModel> GetAllUser()
        {
            IEnumerable<UserModel> users = userRepository.GetallUsers();
            return users;
        }

        public UserModel GetUserByName(string name)
        {
            return userRepository.GetallUsers().Where(user => user.UserName == name).FirstOrDefault();
        }


    }
    
}
