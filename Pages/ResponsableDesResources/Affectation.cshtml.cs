using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class AffectationModel : PageModel
    {
        public Livraison livraison = new Livraison();
        public List<User> users = new List<User>();

        public void OnGet()
        {
            InitializePageData();
        }

        public IActionResult OnPostValidateOrdinateur(int id)
        {
            ServicesPages.gestionLivraison.validateOrdinateur(id);
            InitializePageData(); // Ensure dropdown data is available after POST
            return RedirectToPage();
        }

        public IActionResult OnPostAssignOrdinateur(int besoinId, int departementId)
        {
            if (besoinId <= 0 || departementId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid besoin or departement ID";
                InitializePageData(); // Ensure dropdown data is available after POST
                return RedirectToPage();
            }

            try
            {
                ServicesPages.gestionAffectation.affecterMateriel(besoinId, departementId, "Ordinateur");
                TempData["SuccessMessage"] = "Ordinateur affecté avec succès";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erreur lors de l'affectation: " + ex.Message;
            }

            InitializePageData(); // Ensure dropdown data is available after POST
            return RedirectToPage();
        }

        public IActionResult OnPostValidateImprimante(int id)
        {
            ServicesPages.gestionLivraison.validateImprimante(id);
            InitializePageData(); // Ensure dropdown data is available after POST
            return RedirectToPage();
        }

        public IActionResult OnPostAssignImprimante(int besoinId, int departementId)
        {
            if (besoinId <= 0 || departementId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid besoin or departement ID";
                InitializePageData(); // Ensure dropdown data is available after POST
                return RedirectToPage();
            }

            try
            {
                ServicesPages.gestionAffectation.affecterMateriel(besoinId, departementId, "Imprimante");
                TempData["SuccessMessage"] = "Imprimante affectée avec succès";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erreur lors de l'affectation: " + ex.Message;
            }

            InitializePageData(); // Ensure dropdown data is available after POST
            return RedirectToPage();
        }

        private void InitializePageData()
        {
            livraison = ServicesPages.gestionLivraison.GetLivraison();
            users = ServicesPages.managerUsers.GetDepartement();

            foreach (var imp in livraison.imprimantes)
            {
                var user = ServicesPages.managerUsers.GetUser(imp.AffecteId);
                if (user != null)
                {
                    imp.AffecteName1 = user.Name;
                }
            }

            foreach (var ord in livraison.ordinateurs)
            {
                var user = ServicesPages.managerUsers.GetUser(ord.AffectedId);
                if (user != null)
                {
                    ord.AffecteName1 = user.Name;
                }
            }
        }
    }
}
