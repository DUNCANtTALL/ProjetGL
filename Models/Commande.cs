namespace ProjetGL.Models
{
    public class Commande
    {
        private int idAppelOffre;
        private int idFournisseur;
        private float total;
        private DateTime datelivraison;
        private DateTime dategarantie;
        private List<Materielle> materielles;

        public Commande(int idAppelOffre, int idFournisseur, float total, DateTime datelivraison, DateTime dategarantie, List<Materielle> materielles)
        {
            this.IdAppelOffre = idAppelOffre;
            this.IdFournisseur = idFournisseur;
            this.Total = total;
            this.Datelivraison = datelivraison;
            this.Dategarantie = dategarantie;
            this.Materielles = materielles;
        }

        public int IdAppelOffre { get => idAppelOffre; set => idAppelOffre = value; }
        public int IdFournisseur { get => idFournisseur; set => idFournisseur = value; }
        public float Total { get => total; set => total = value; }
        public DateTime Datelivraison { get => datelivraison; set => datelivraison = value; }
        public DateTime Dategarantie { get => dategarantie; set => dategarantie = value; }
        public List<Materielle> Materielles { get => materielles; set => materielles = value; }
    }
}
