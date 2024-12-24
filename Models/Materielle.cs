namespace ProjetGL.Models
{
    public class Materielle
    {
        private string marque;
        private int prix;

        public Materielle(string marque, int prix)
        {
            this.marque = marque;
            this.prix = prix;
        }

        public string Marque { get => marque; set => marque = value; }
        public int Prix { get => prix; set => prix = value; }
    }
}
