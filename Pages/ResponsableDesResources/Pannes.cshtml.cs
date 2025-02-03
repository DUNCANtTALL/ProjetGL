using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class PannesModel : PageModel
    {

        public List<Constat> constats { get; set; } = new List<Constat>();
        public void OnGet()
        {
            constats = ServicesPages.gestionConstat.ObtenirTousLesConstats();
        }
    }
}
