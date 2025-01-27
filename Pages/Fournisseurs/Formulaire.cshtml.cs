using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Security.Claims;
using System.Security.Principal;

namespace ProjetGL.Pages.Fournisseur
{
    public class FormulaireModel : PageModel
    {
      
        public string MsgSuccess { get; set; }
        public string MsgError { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        [BindProperty]
        public Commande soumission { get; set; } = new Commande();

        public List<Commande> Liste { get; set; } = new List<Commande>();

        public void OnGet()
        {
            Console.WriteLine($"Received ID: {Id}, User ID: {UserId}");
           


        }

        public IActionResult OnPost()
        {
            try
            {
                soumission.IdFournisseur = UserId;
                soumission.IdAppelOffre = Id;

                // Calculate total for computers and printers
                float totalOrdinateurs = (float)(soumission.PrixUnitaire * soumission.Quantite);
                float totalImprimantes = (float)(soumission.PrixUnitaireImprimate * soumission.QuantiteImprimantes);
                soumission.Total = totalOrdinateurs + totalImprimantes;

                // Save the command and get the ID
                int newId = ServicesPages.gestionCommande.addCommande(soumission);  // This will return the inserted ID

                // Check if the ID was set correctly
                if (newId == 0)
                {
                    MsgError = "Failed to create the command.";
                    return Page();
                }

                // Now you can directly use newId for redirection
                Console.WriteLine($"Command ID after add: {newId}");

                MsgSuccess = "La soumission a été ajoutée avec succès.";
                return RedirectToPage("/Fournisseurs/AjouterMateriel", new { id = newId });  // Use the newly inserted ID here
            }
            catch (Exception ex)
            {
                MsgError = "Une erreur s'est produite : " + ex.Message;
                return Page();
            }
        }


    }
}
