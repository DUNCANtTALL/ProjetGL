using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class ViewBesionModel : PageModel
    {
        public List<Besion> Besions { get; set; }

        public void OnGet()
        {
            Besions = ServicesPages.gestionBesoin.GetValidatedBesions(); 

            foreach (var besion in Besions)
            {
                besion.Ordinateurs = ServicesPages.gestionBesoin.GetOrdinateurs(besion.Id);
                besion.Imprimantes = ServicesPages.gestionBesoin.GetImprimante(besion.Id);
                besion.Status = ServicesPages.gestionBesoin.status(besion.Id);
            }
        }
    }
}
