using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IUserRepository
    {
        bool AddUser(AccountsUser user);
      
        bool DeleteUser(string username);
        IEnumerable<AccountsUser> GetallUsers();
        bool UpdateUser(AccountsUser user);
    }
}