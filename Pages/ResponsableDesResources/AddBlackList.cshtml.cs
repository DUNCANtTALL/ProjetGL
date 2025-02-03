using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class AddBlackListModel : PageModel
    {

        User User;

        [BindProperty]
        public string Raison { get; set; }


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
            User user =  ServicesPages.managerUsers.GetUserByName(User.Name);
            ServicesPages.gestionListeNoir.AjouterListeNoir(user, Raison);

        }
    }
}
