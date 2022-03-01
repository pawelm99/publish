using Projekt1.Interface;
using Projekt1.Models;

namespace Projekt1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }
        public User GetByName(string name)
        {
            return _userRepository.GetByName(name);
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id); 
        }
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);  
        }



    }
}
