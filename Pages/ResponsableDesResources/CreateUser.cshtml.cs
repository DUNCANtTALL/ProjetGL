using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class CreateUserModel : PageModel
    {


        User User;
        public User user
        {
            get => User;
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
