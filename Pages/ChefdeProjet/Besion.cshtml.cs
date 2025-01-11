using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Collections.Generic;

namespace ProjetGL.Pages.ChefdeProjet
{
    public class BesionModel : PageModel
    {
        public List<Besion> Besions { get; set; }

        public void OnGet()
        {
            Besions = ServicesPages.gestionBesoin.GetBesions();

            foreach (var besion in Besions)
            {
                besion.Ordinateurs = ServicesPages.gestionBesoin.GetOrdinateurs(besion.Id);
                besion.Imprimantes = ServicesPages.gestionBesoin.GetImprimante(besion.Id);
                besion.Status = ServicesPages.gestionBesoin.status(besion.Id);


            }


        }
        public IActionResult OnPostReject(int id)
        {
            ServicesPages.gestionBesoin.DeleteBesion(id); 
            return RedirectToPage();

        }

        public IActionResult OnPostValidate(int id)
        {
            // Validate the selected Besion
            ServicesPages.gestionBesoin.Validate(id);
            return RedirectToPage();
        }
    }
}
