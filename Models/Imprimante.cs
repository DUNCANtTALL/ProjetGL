namespace ProjetGL.Models
{
    public class Imprimante
    {
        private string vitesse;
        private string resoluton;
        private string marsque;
        private int besionID;

        public Imprimante(string vitesse, string resoluton, string marsque, int besionID)
        {
            this.Vitesse = vitesse;
            this.Resoluton = resoluton;
            this.Marsque = marsque;
            this.BesionID = besionID;
        }
        public Imprimante()
        {
            
        }

        public string Vitesse { get => vitesse; set => vitesse = value; }
        public string Resoluton { get => resoluton; set => resoluton = value; }
        public string Marsque { get => marsque; set => marsque = value; }
        public int BesionID { get => besionID; set => besionID = value; }
    }
}
