using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Data.SqlClient;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class VoirCommandeModel : PageModel
    {
        public List<Commande> Commandes { get; set; }

        [BindProperty]
        public int CommandeId { get; set; }

        [BindProperty]
        public int FournisseurId { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostValider()
        {
            if (ValiderCommande(CommandeId))
            {
                TempData["Message"] = "Commande validée avec succès.";
                return RedirectToPage();
            }

            ModelState.AddModelError("", "Une erreur s'est produite lors de la validation.");
            return Page();
        }

        public IActionResult OnPostRejeter()
        {
            if (RejeterCommande(CommandeId))
            {
                TempData["Message"] = "Commande rejetée avec succès.";
                return RedirectToPage();
            }

            ModelState.AddModelError("", "Une erreur s'est produite lors du rejet.");
            return Page();
        }

        public IActionResult OnPostConversation()
        {
            TempData["Message"] = $"Conversation initiée avec le fournisseur ID: {FournisseurId}.";
            // Redirection vers une page ou un système de messagerie.
            return RedirectToPage("/Admin/Conversation", new { fournisseurId = FournisseurId });
        }

        

        private bool ValiderCommande(int commandeId)
        {
            try
            {
               ServicesPages.gestionCommande.validateCommande(commandeId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool RejeterCommande(int commandeId)
        {
            return true;

        }
    }
}
