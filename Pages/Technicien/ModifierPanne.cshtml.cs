using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Pages.Technicien
{
    public class ModifierPanneModel : PageModel
    {
      

       

        [BindProperty]
        public Pannes PanneModifiee { get; set; }

        public IActionResult OnGet(int id)
        {
            PanneModifiee = ServicesPages.gestionPanne.ObtenirPanneParId(id);
            if (PanneModifiee == null)
                return RedirectToPage("Panne");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            ServicesPages.gestionPanne.MettreAJourPanne(PanneModifiee);
            return RedirectToPage("Panne");
        }
    }
}
