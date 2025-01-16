namespace ProjetGL.Models
{
    public class Commande
    {
        public int Id { get; set; }

        private int idAppelOffre;
        private int idFournisseur;
        private float total;
        private DateTime datelivraison;
        private DateTime dategarantie;
        private string marque;

        public decimal PrixUnitaire { get; set; }
        private int quantite; 
        private List<Materielle> materielles;

        public Commande(int id, int idAppelOffre, int idFournisseur, float total, DateTime datelivraison, DateTime dategarantie, string marque, decimal prixUnitaire, int quantite)
        {
            Id = id;
            this.idAppelOffre = idAppelOffre;
            this.idFournisseur = idFournisseur;
            this.total = total;
            this.datelivraison = datelivraison;
            this.dategarantie = dategarantie;
            this.marque = marque;
            PrixUnitaire = prixUnitaire;
            this.Quantite = quantite;
        }
        public Commande()
        {
            
        }

        public int IdAppelOffre { get => idAppelOffre; set => idAppelOffre = value; }
        public int IdFournisseur { get => idFournisseur; set => idFournisseur = value; }
        public float Total { get => total; set => total = value; }
        public DateTime Datelivraison { get => datelivraison; set => datelivraison = value; }
        public DateTime Dategarantie { get => dategarantie; set => dategarantie = value; }
        public List<Materielle> Materielles { get => materielles; set => materielles = value; }
        public string Marque { get => marque; set => marque = value; }
        public int Quantite { get => quantite; set => quantite = value; }
    }
}
