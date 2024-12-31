using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages
{
    public class RegisterModel : PageModel
    {
        User User; 
        public User user
        {   get => User;  
            set => User = value; 
        }
        public void OnGet()
        {

        }
       public void OnPost(User User)
        {
            ServicesPages.managerUsers.addUser(User);
        }
    }
}
