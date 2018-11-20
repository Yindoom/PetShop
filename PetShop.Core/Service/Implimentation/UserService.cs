using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Core.Service.Implimentation
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public List<User> GetUsers()
        {
            return _userRepository.GetAllUsers().ToList();
        }

        public User GetUser(LoginInput login)
        {
            return _userRepository.GetByUsername(login);
        }
    }
}