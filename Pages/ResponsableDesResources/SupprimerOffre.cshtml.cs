using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Identity.Client;
using ProjetGL.Buisness;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class SupprimerOffreModel : PageModel
    {

        [BindProperty]
        public string MsgSuccess { get; set; }
        public string MsgError { get; set; }

        public int id { get; set; }
        public void OnGet()
        {
        }

        /*public IActionResult OnPostDelete(int id)
        {
            try
            {
                var appelDoffre = ServicesPages.gestionAppeleDoffre.FindAppelOffre(id);

                if (appelDoffre == null)
                {
                    MsgError = "L'appel d'offre avec le id spécifié n'existe pas.";
                    return Page();
                }

                ServicesPages.gestionAppeleDoffre.DeleteAppeleDoffre(id);
                MsgSuccess = "L'appel d'offre a été supprimé avec succès.";
                return Page();
            }
            catch (Exception ex)
            {
                MsgError = "Une erreur s'est produite : " + ex.Message;
                return Page();
            }
        }*/

        public IActionResult OnPostDelete(int Id)
        {
            try
            {
                var appelDoffre = ServicesPages.gestionAppeleDoffre.FindAppelOffre(Id);

                if (appelDoffre == null)
                {
                    MsgError = "L'appel d'offre avec l'ID spécifié n'existe pas.";
                    return Page();
                }

                ServicesPages.gestionAppeleDoffre.DeleteAppeleDoffre(Id);
                MsgSuccess = "L'appel d'offre a été supprimé avec succès.";
                return Page();
            }
            catch (Exception ex)
            {
                MsgError = "Une erreur s'est produite : " + ex.Message;
                return Page();
            }
        }


    }
}
