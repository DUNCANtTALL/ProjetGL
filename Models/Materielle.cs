namespace ProjetGL.Models
{
    public class Materielle
    {
        private string marque;
        private int prix;
        private int quantite;
        private int CommandeId;

        public Materielle(string marque, int prix, int quantite, int commandeId)
        {
            this.marque = marque;
            this.prix = prix;
            this.quantite = quantite;
            CommandeId = commandeId;
        }

        public string Marque { get => marque; set => marque = value; }
        public int Prix { get => prix; set => prix = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public int CommandeId1 { get => CommandeId; set => CommandeId = value; }
    }
}
