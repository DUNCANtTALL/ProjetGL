using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class VoirCommandeDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CommandeId { get; set; }
        [BindProperty]
        public int FournisseurId { get; set; }

        public Commande commande;
        public User fournisseur; 


        public List<Ordinateur> ordinateurs = new List<Ordinateur>();
        public List<Imprimante> imprimantes = new List<Imprimante>();
        public void OnGet()
        {
            fournisseur = ServicesPages.managerUsers.GetUser(FournisseurId); 
            commande = ServicesPages.gestionCommande.GetCommande(CommandeId);
            imprimantes = ServicesPages.gestionCommande.GetImprimantes(CommandeId);
            ordinateurs = ServicesPages.gestionCommande.GetOrdinateurs(CommandeId);



        }
    }
}
