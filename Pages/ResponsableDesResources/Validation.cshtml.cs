using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class ValidationModel : PageModel
    {
        public Societe Fournisseur { get; set; } = new Societe(); 

        [BindProperty(SupportsGet = true)]
        public int fournisseurId { get; set; }

        public void OnGet()
        {
            // Initialiser ou charger les données du fournisseur si nécessaire
            // Exemple : Fournisseur = ServicesPages.gestionFournisseur.GetFournisseurById(FournisseurId);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Fournisseur.id = fournisseurId; 
                ServicesPages.gestionFournisseur.AddFournisseur(Fournisseur);
                return RedirectToPage("/ResponsableDesResources/Fournisseurs");
            }

            // Ajouter des messages d'erreur pour aider à diagnostiquer les problèmes
            ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de la validation du fournisseur.");
            return Page();
        }
    }
}
