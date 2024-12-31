using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Security.Principal;

namespace ProjetGL.Pages
{
    public class LoginModel : PageModel
    {
        User user;
        string MsgError;

        public User User
        {
            get => user;
            set => user = value;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(User user)
        {
            // Retrieve the user based on their name
            User = ServicesPages.managerUsers.GetUser(user.Email);

            if (User == null)
            {
                MsgError = "User not found";
                return Page();
            }

            if (User.Password != user.Password)
            {
                MsgError = "Wrong password";
                return Page();
            }

            var redirectPage = User switch
            {
                Fournisseur => "/Fournisseur",
                ResponsableDesResources => "/ResponsableDesResources",

                ChefDeProjet => "/ChefDeProjet",
                Departement => "/Depatement",
                _ => "/Index" 
            };

            return RedirectToPage(redirectPage);
        }


    }
}
