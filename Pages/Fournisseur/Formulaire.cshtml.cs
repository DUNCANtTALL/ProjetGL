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
                // Retrieve the current user's ID
               
                    soumission.IdFournisseur = UserId;
                    soumission.IdAppelOffre = Id; 
                    float total = (float)(soumission.PrixUnitaire * soumission.Quantite); // Calculate the total price
                    soumission.Total = total;
                Console.WriteLine( "total"+total);
                ServicesPages.gestionCommande.addCommande(soumission); // Add the command
                    MsgSuccess = "La soumission a été ajoutée avec succès."; // Success message
              

                return Page();
            }
            catch (Exception ex)
            {
                MsgError = "Une erreur s'est produite : " + ex.Message; // Error message
                return Page();
            }
        }
    }
}
