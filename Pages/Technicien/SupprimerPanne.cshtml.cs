using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Pages.Technicien
{
    public class SupprimerPanneModel : PageModel
    {
        

        

        [BindProperty]
        public Pannes PanneASupprimer { get; set; }

        public IActionResult OnGet(int id)
        {
            PanneASupprimer = ServicesPages.gestionPanne.ObtenirPanneParId(id);
            if (PanneASupprimer == null)
                return RedirectToPage("Panne");

            return Page();
        }

        public IActionResult OnPost()
        {
            ServicesPages.gestionPanne.SupprimerPanne(PanneASupprimer.Id);
            return RedirectToPage("Panne");
        }
    }
}
