using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.Departement
{
    public class AffectationsModel : PageModel
    {

        public List<Ordinateur> ordinateurs = new List<Ordinateur>();
        public List<Imprimante> imprimantes = new List<Imprimante>();

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }
        public void OnGet()
        {
            ordinateurs = ServicesPages.gestionAffectation.GetOrdinateur(UserId);
            imprimantes = ServicesPages.gestionAffectation.GetImprimante(UserId); 
        }
    }
}
