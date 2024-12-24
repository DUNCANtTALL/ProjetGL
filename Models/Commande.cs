namespace ProjetGL.Models
{
    public class Commande
    {
        private float total;
        private string datelivraison;
        private string dategarantie;
        private List<Materielle> materilles;

        public Commande(float total, string datelivraison, string dategarantie)
        {
            this.Total = total;
            this.Datelivraison = datelivraison;
            this.Dategarantie = dategarantie;
            this.Materilles = new List<Materielle>();
        }
        public void add(Materielle materielle)
        {
            materilles.Add(materielle);
        }
        public float Total { get => total; set => total = value; }
        public string Datelivraison { get => datelivraison; set => datelivraison = value; }
        public string Dategarantie { get => dategarantie; set => dategarantie = value; }
        public List<Materielle> Materilles { get => materilles; set => materilles = value; }
    }
}
