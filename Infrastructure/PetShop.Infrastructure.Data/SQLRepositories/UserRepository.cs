using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.SQLRepositories
{
    public class UserRepository : IUserRepository
    {
        private PetShopContext _ctx;

        public UserRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }

        public User GetByUsername(LoginInput login)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username == login.Username);
        }
    }
}