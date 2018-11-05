using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Domain
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetByUsername(string user);
    }
}