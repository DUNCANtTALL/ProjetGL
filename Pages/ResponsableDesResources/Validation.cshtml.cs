using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class ValidationModel : PageModel
    {
        [BindProperty]
        public Societe Fournisseur { get; set; } = new Societe();

        [BindProperty(SupportsGet = true)]
        public int fournisseurId { get; set; }

        public void OnGet()
        {
            // Example: Load existing data if necessary
            // Fournisseur = ServicesPages.gestionFournisseur.GetFournisseurById(fournisseurId);
            Fournisseur.id = fournisseurId;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
                ServicesPages.gestionFournisseur.AddFournisseur(Fournisseur);
                return RedirectToPage("/ResponsableDesResources/VoirCommande");
            }

            ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de la validation du fournisseur.");
            return Page();
        }
    }

}
