using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public string MsgError { get; private set; }

        public IActionResult OnPost()
        {
            // Authenticate the user
            var authenticatedUser = ServicesPages.managerUsers.GetUser(User.Email);

            if (authenticatedUser == null)
            {
                MsgError = "User not found";
                return Page();
            }

            if (authenticatedUser.Password != User.Password)
            {
                MsgError = "Wrong password";
                return Page();
            }

            // Redirect based on user type
            return authenticatedUser.Type switch
            {
                "Fournisseur" => RedirectToPage("Fournisseurs/Home", new { userId = authenticatedUser.UserId }),
                "Chef De Projet" => RedirectToPage("/ChefdeProjet/Home", new { userId = authenticatedUser.UserId }),
                "Departement" => RedirectToPage("/Departement/Affectations", new { userId = authenticatedUser.UserId }),
                _ => RedirectToPage("/ResponsableDesResources/Home", new { userId = authenticatedUser.UserId }),
            };
        }
    }
}
