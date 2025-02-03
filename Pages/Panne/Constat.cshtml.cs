using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Pages.Panne
{
    public class ConstatModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int PanneId { get; set; }

        [BindProperty]
        public Constat NouveauConstat { get; set; } = new Constat();

        public List<Constat> Constats { get; set; } = new List<Constat>();

        public void OnGet(int panneId)
        {
            PanneId = panneId;
            NouveauConstat.PanneId = PanneId; // Assurer que PanneId est bien défini
            Constats = ServicesPages.gestionConstat.ObtenirConstatsParPanneId(PanneId);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NouveauConstat.PanneId = PanneId; // Correction ici
            ServicesPages.gestionConstat.AjouterConstat(NouveauConstat);

            return RedirectToPage(new { PanneId });
        }

        public IActionResult OnPostSupprimer(int id)
        {
            ServicesPages.gestionConstat.SupprimerConstat(id);
            return RedirectToPage(new { PanneId });
        }


    }
}
