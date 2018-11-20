using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Service
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(LoginInput login);
    }
}