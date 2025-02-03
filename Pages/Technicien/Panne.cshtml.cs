using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Data;
using ProjetGL.Models;
namespace ProjetGL.Pages.Technicien
{
    public class PanneModel : PageModel
    {
        public List<Pannes> Pannes { get; set; } = new List<Pannes>();

        //private readonly IDataPanne _dataPanne;

        public PanneModel()
        {
            //_dataPanne = dataPanne;

        }

      

        public void OnGet()
        {
            Pannes = ServicesPages.gestionPanne.ObtenirToutesLesPannes();
        }
    }
}
