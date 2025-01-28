using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class EditOffreModel : PageModel
    {
        [BindProperty]
        public AppelD_offre AppelDOffre { get; set; }

        public string MsgSuccess { get; set; }
        public string MsgError { get; set; }




        public IActionResult OnGet(int id)
        {
            // Afficher l'ID dans les logs pour le diagnostic
            Console.WriteLine($"ID re�u dans OnGet : {id}");

            // R�cup�rer l'appel d'offre � partir de l'ID
            AppelDOffre = ServicesPages.gestionAppeleDoffre.FindAppelOffre(id);
            if (AppelDOffre == null)
            {
                MsgError = "L'appel d'offre avec l'ID sp�cifi� n'existe pas.";
                return Page();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                Console.WriteLine("Tentative de mise � jour de l'appel d'offre");

                // Afficher l'ID de l'appel d'offre avant la mise � jour
                Console.WriteLine($"ID de l'appel d'offre � mettre � jour : {AppelDOffre.Id}");

                if (AppelDOffre.Id == 0)
                {
                    MsgError = "L'ID de l'appel d'offre est invalide.";
                    return Page();
                }

                // V�rifier que l'appel d'offre existe avant de proc�der � la mise � jour
                var existingAppelDOffre = ServicesPages.gestionAppeleDoffre.FindAppelOffre(AppelDOffre.Id);
                if (existingAppelDOffre == null)
                {
                    MsgError = "L'appel d'offre avec l'ID sp�cifi� n'existe pas.";
                    return Page();
                }

                // Mettre � jour l'appel d'offre
                ServicesPages.gestionAppeleDoffre.UpdateAppelDoffre(AppelDOffre.Id, AppelDOffre.Titre, AppelDOffre.DateDebut, AppelDOffre.DateFin, AppelDOffre.Description);

                MsgSuccess = "L'appel d'offre a �t� mis � jour avec succ�s.";
                Console.WriteLine("Mise � jour r�ussie");

                return Page();
            }
            catch (Exception ex)
            {
                MsgError = "Une erreur s'est produite : " + ex.Message;
                Console.WriteLine("Erreur : " + ex.Message);
                return Page();
            }
        }

    }

}

