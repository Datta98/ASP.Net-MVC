using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class UserORMRepository : IUserRepository
    {
        public UserDetailsEntities userDetails = new UserDetailsEntities();
       
        public bool AddUser(AccountsUser user)
        {            
            bool status;
            try
            {
                userDetails.AccountsUsers.Add(user);
                userDetails.SaveChanges();
                status = true;
            }
            catch (Exception)
            {               
                status = false;
            }
            return status;
        }
       
        public bool DeleteUser(string username)
        {
            bool status;
            try
            {
                AccountsUser _accountsUser = userDetails.AccountsUsers.Where(u => u.UserName == username).FirstOrDefault();
                if (_accountsUser != null)
                {
                    userDetails.AccountsUsers.Remove(_accountsUser);
                    userDetails.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }   
             
       
        public bool UpdateUser(AccountsUser user)
        {
            bool status;
            try
            {
                AccountsUser _accountsUser = userDetails.AccountsUsers.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (_accountsUser != null)
                {
                    _accountsUser.UserName = user.UserName;
                    _accountsUser.EmailId = user.EmailId;
                    _accountsUser.Password = user.Password;
                    userDetails.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

       public IEnumerable<AccountsUser> GetallUsers()
        {
            return userDetails.AccountsUsers.ToList();
        }
    }
}