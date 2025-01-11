using ProjetGL.Models;

namespace ProjetGL.Data
{
    interface IDataListNoir
    {
        public void AddUser(User user, string raison);
        public void DeleteUser(int userID);
        public List<User> GetAllUsers();
    }
}
