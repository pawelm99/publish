using Projekt1.Interface;
using Projekt1.Models;

namespace Projekt1.Repository
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>() {
            new User(1,"Tomek","1234"),
            new User(2,"Tomek2","1234"), 
            new User(3,"Tomek3","1234") };

        public UserRepository()
        {

        }

        public IEnumerable<User> GetAllUser()
        {
            return _users;
        }
        public User GetByName(string name)
        {
            var userId = _users.SingleOrDefault(x => x.Login == name);
            return userId;
        }
        public User AddUser(User user)
        {
            user.Id = _users.Count +1;
            _users.Add(user);
            return user;
            // sprawdz to czy to nie wojd
        }
        public void UpdateUser(User user)
        {
            var userId = _users.SingleOrDefault(x => x.Id == user.Id); // nwm czy dobrze
            if(userId == null)
            {
                throw new Exception("Brak usera!");
            }
            userId.Login = user.Login;
            userId.Password = user.Password;

        }
        public void DeleteUser(int id)
        {
            var userId = _users.SingleOrDefault(x => x.Id == id);
            _users.Remove(userId);
        }

    }
}
