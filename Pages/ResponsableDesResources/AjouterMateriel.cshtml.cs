using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class AjouterMaterielModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty]
        public Ordinateur Ordinateur { get; set; }

        [BindProperty]
        public Imprimante Imprimante { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
           

            // Add Imprimante
            if (!string.IsNullOrEmpty(Imprimante.Marsque) && Imprimante.Quantity > 0)
            {
                Imprimante.BesionID = id;
                ServicesPages.gestionAppeleDoffre.addImprimante(Imprimante);
                Console.WriteLine("id:"+Imprimante.BesionID);
                Console.WriteLine("impr : " + Imprimante.Marsque);
            }

            // Add Ordinateur
            if (!string.IsNullOrEmpty(Ordinateur.Marque) && Ordinateur.Quantity > 0)
            {
                Ordinateur.BesoinId = id;
                ServicesPages.gestionAppeleDoffre.addOrdinateur(Ordinateur);
            }

            return Page();
        }
    }
}