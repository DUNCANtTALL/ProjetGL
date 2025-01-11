using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionUsers
    {
        IDataUsers data = new DataUsers(); 
       
 

        public List<User> GetUsers()
        {
            return data.GetAllUsers() ; 
        }
        public void addUser(User user)
        {
            data.AddUser(user);
        }
        public void DeleteUser(User user)
        {
            data.DeleteUser(user.Name);
        }

        public User GetUser(string name )
        {
            return data.FindUser(name);    
        }
        public User GetUser(int id)
        {
            return data.FindUserByID(id);
        }





    }
}
