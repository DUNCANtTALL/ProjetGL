using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.Panne
{
    public class AjouterConstatModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int PanneId { get; set; } // 📌 ID de la panne reçu dans l'URL

        [BindProperty]
        public Constat NouveauConstat { get; set; } = new Constat();

        public string Message { get; set; } = "";

        public void OnGet(int panneId)
        {
            PanneId = panneId;
            NouveauConstat.PanneId = PanneId;
            Console.WriteLine($"OnGet: PanneId = {PanneId}"); // ✅ Vérifie si l'ID est reçu
        }

        public IActionResult OnPost()
        {
            Console.WriteLine($"OnPost: PanneId = {PanneId}");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    foreach (var err in error.Value.Errors)
                    {
                        Console.WriteLine($"Erreur sur {error.Key}: {err.ErrorMessage}");
                    }
                }
                return Page();
            }

            NouveauConstat.PanneId = PanneId; // ⚠️ Vérifier que PanneId est bien passé
            ServicesPages.gestionConstat.AjouterConstat(NouveauConstat);
            return RedirectToPage("/Panne/Panne");
        }

    }
}
