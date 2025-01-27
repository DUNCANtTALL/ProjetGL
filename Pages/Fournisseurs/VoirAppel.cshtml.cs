using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.Fournisseurs
{
    public class VoirAppelModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public AppelD_offre appel;

        public List<Ordinateur> ordinateurs;
        public List<Imprimante> imprimantes; 
        public void OnGet()
        {
            Console.WriteLine(""+id);
           appel =  ServicesPages.gestionAppeleDoffre.GetAppel(id);
            imprimantes = ServicesPages.gestionAppeleDoffre.GetImprimante(id);
            ordinateurs = ServicesPages.gestionAppeleDoffre.GetOrdinateurs(id);



        }
    }
}
