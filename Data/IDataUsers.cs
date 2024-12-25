using ProjetGL.Models;
using System.Security.Principal;

namespace ProjetGL.Data
{
    public interface IDataUsers
    {
        void AddUser(User user);
        User FindUser(string username);
        void UpdateUser(User user);
        void DeleteUser(string username);
        List<User> GetAllUsers();
    }
}
