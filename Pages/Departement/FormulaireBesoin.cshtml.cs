using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.Departement
{
    public class FormulaireBesoinModel : PageModel
    {
        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public List<Ordinateur> Ordinateurs { get; set; } = new List<Ordinateur>();

        [BindProperty]
        public List<int> OrdinateurQuantities { get; set; } = new List<int>();

        [BindProperty]
        public List<Imprimante> Imprimantes { get; set; } = new List<Imprimante>();
        
        

        [BindProperty]
        public List<int> ImprimanteQuantities { get; set; } = new List<int>();

        public IActionResult OnPost()
        {
            // Validate description and items
            if (string.IsNullOrWhiteSpace(Description))
            {
                ModelState.AddModelError("Description", "Description cannot be empty.");
                return Page();
            }

            if ((Ordinateurs == null || Ordinateurs.Count == 0) &&
                (Imprimantes == null || Imprimantes.Count == 0))
            {
                ModelState.AddModelError("Items", "At least one Ordinateur or Imprimante must be added.");
                return Page();
            }

            try
            {
                // Create the Besoin
                Besion newBesion = ServicesPages.gestionBesoin.CreateBesoin(Description);

                // Process Ordinateurs
                ProcessOrdinateurs(newBesion);

                // Process Imprimantes
                ProcessImprimantes(newBesion);

                TempData["SuccessMessage"] = "Besoin and related items have been successfully saved.";
                return RedirectToPage("/Departement/Home");
            }
            catch (Exception ex)
            {
                // Log the full exception
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return Page();
            }
        }

        private void ProcessOrdinateurs(Besion newBesion)
        {
            for (int index = 0; index < Ordinateurs.Count; index++)
            {
                var ordinateurVm = Ordinateurs[index];
                int quantity = (index < OrdinateurQuantities.Count) ? OrdinateurQuantities[index] : 1;

                for (int i = 0; i < quantity; i++)
                {
                    var ordinateur = new Ordinateur
                    (
                        ordinateurVm.Marque,
                        ordinateurVm.Cpu,
                        ordinateurVm.Ram,
                        ordinateurVm.Disque,
                        ordinateurVm.Ecran,
                        newBesion.Id
                    );
                    ServicesPages.gestionBesoin.AddOrdinateur(ordinateur);
                }
            }
        }

        private void ProcessImprimantes(Besion newBesion)
        {
            // Comprehensive logging
            Console.WriteLine($"Processing Imprimantes. Total count: {Imprimantes?.Count}");

            if (Imprimantes != null)
            {
                for (int index = 0; index < Imprimantes.Count; index++)
                {
                    var imprimanteVm = Imprimantes[index];

                    // Detailed logging
                    Console.WriteLine($"Imprimante {index}:");
                    Console.WriteLine($"  Vitesse: {imprimanteVm.Vitesse}");
                    Console.WriteLine($"  Resolution: {imprimanteVm.Resoluton}");
                    Console.WriteLine($"  Marque: {imprimanteVm.Marsque}");

                    int quantity = (index < ImprimanteQuantities.Count) ? ImprimanteQuantities[index] : 1;

                    for (int i = 0; i < quantity; i++)
                    {
                        var imprimante = new Imprimante
                        (
                            imprimanteVm.Vitesse,
                            imprimanteVm.Resoluton,
                            imprimanteVm.Marsque,
                            newBesion.Id
                        );

                        ServicesPages.gestionBesoin.AddImprimante(imprimante);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Imprimantes to process.");
            }
        }
    }
}
