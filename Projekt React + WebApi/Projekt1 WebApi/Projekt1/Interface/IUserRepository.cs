using Projekt1.Models;

namespace Projekt1.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();

        User GetByName(string name);

        User AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
