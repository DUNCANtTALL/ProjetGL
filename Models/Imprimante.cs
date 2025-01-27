namespace ProjetGL.Models
{
    public class Imprimante
    {
        private string vitesse;
        private string resoluton;
        private string marsque;
        private int besionID;
        private int quantity;
        private bool status;
        private int affecteId; 
        private string AffecteName;


        public Imprimante(string vitesse, string resoluton, string marsque, int besionID)
        {
            this.Vitesse = vitesse;
            this.Resoluton = resoluton;
            this.Marsque = marsque;
            this.BesionID = besionID;
        }
        public Imprimante(string vitesse, string resoluton, string marsque, int besionID , int quantity)
        {
            this.Vitesse = vitesse;
            this.Resoluton = resoluton;
            this.Marsque = marsque;
            this.BesionID = besionID;
            this.Quantity = quantity; 
        }
        public Imprimante()
        {
            
        }

        public string Vitesse { get => vitesse; set => vitesse = value; }
        public string Resoluton { get => resoluton; set => resoluton = value; }
        public string Marsque { get => marsque; set => marsque = value; }
        public int BesionID { get => besionID; set => besionID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool Status { get => status; set => status = value; }
        public int AffecteId { get => affecteId; set => affecteId = value; }
        public string AffecteName1 { get => AffecteName; set => AffecteName = value; }
    }
}
