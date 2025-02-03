using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Pages.Technicien
{
    public class AjouterPanneModel : PageModel
    {
       

        [BindProperty]
        public Pannes NouvellePanne { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            ServicesPages.gestionPanne.AjouterPanne(NouvellePanne);
            return RedirectToPage("Panne");
        }
    }
}
