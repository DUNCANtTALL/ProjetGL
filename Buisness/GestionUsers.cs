using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionUsers
    {
        List<User> users ;

        public GestionUsers()
        {
            users = new List<User>();   
            
        }

        public List<User> GetUsers()
        {
            return users ; 
        }
        public void addUser(User user)
        {
            users.Add(user);
        }
        public void DeleteUser(User user)
        {
            users.Remove(user);
        }
        public User GetUser(string name )
        {
            foreach (User user in users)
            {
                if(user.Name == name ) return user;
            }
            return null;
        }


        
    }
}
