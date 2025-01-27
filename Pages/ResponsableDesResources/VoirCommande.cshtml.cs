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
        public List<User> fournisseur = new List<User>();
        public List<AppelD_offre> appels = new List<AppelD_offre>(); 

        [BindProperty]
        public int CommandeId { get; set; }

        [BindProperty]
        public int FournisseurId { get; set; }

        public void OnGet()
        {
            Commandes = ServicesPages.gestionCommande.GetAllCommande();

            // Clear the existing lists to avoid duplicates
            fournisseur.Clear();
            appels.Clear();

            foreach (var c in Commandes)
            {
                var user = ServicesPages.managerUsers.GetUser(c.IdFournisseur);
                if (user != null )
                {
                    fournisseur.Add(user);
                }

                var appel = ServicesPages.gestionAppeleDoffre.GetAppel(c.IdFournisseur);
                if (appel != null && !appels.Contains(appel))
                {
                    appels.Add(appel);
                }
            }
        }



        public IActionResult OnPostValider()
        {
            if (ValiderCommande(CommandeId))
            {
                TempData["Message"] = "Commande validée avec succès.";
                return RedirectToPage("/ResponsableDesResources/Validation", new { fournisseurId = FournisseurId });

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
            return RedirectToPage("/ResponsableDesResources/Conversation", new { fournisseurId = FournisseurId });
        }
        public IActionResult OnPostVoir()
        {
            TempData["Message"] = $"Conversation initiée avec le fournisseur ID: {FournisseurId}.";
            // Redirection vers une page ou un système de messagerie.
            return RedirectToPage("/ResponsableDesResources/VoirCommandeDetails", new { CommandeId = CommandeId , FournisseurId  = FournisseurId });
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
