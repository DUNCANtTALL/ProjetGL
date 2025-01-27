using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.Appelsdoffres
{
    public class AppelsDoffresModel : PageModel
    {


        [BindProperty]
        public string MsgSuccess { get; set; }
        public string MsgError { get; set; }

        public AppelD_offre AppelDOffre { get; set; }

        public List<AppelD_offre> Liste { get; set; } = new List<AppelD_offre>();

        public void OnGet()
        {
            try
            {
                // R�cup�rer la liste des appels d'offres
                Liste = ServicesPages.gestionAppeleDoffre.GetAppeleDoffres();

                if (Liste != null && Liste.Count > 0)
                {
                    MsgSuccess = "Les appels d'offres ont �t� affich�s avec succ�s.";
                }
                else
                {
                    MsgError = "Aucun appel d'offre n'est disponible pour le moment.";
                }
            }
            catch (Exception ex)
            {
                MsgError = "Une erreur s'est produite : " + ex.Message;
            }
        }
        public IActionResult OnPost(AppelD_offre AppelDOffre)
        {

            try
            {
                ServicesPages.gestionAppeleDoffre.addAppeleDoffre(AppelDOffre);
                MsgSuccess = "L'appel d'offre a �t� ajout� avec succ�s."; // Message de succ�s  
                return Page();
            }
            catch (Exception ex)
            {
                MsgError = "Une erreur s'est produite : " + ex.Message; // Message d'erreur  
                return Page();
            }

        }
    }
}