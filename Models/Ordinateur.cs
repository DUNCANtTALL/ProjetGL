namespace ProjetGL.Models
{
    public class Ordinateur
    {
        private string marque;
        private string cpu;
        private string ram;
        private string disque;
        private string ecran;
        private int besoinId;

        public Ordinateur(string marque, string cpu, string ram, string disque, string ecran, int besoinId)
        {
            this.Marque = marque;
            this.Cpu = cpu;
            this.Ram = ram;
            this.Disque = disque;
            this.Ecran = ecran;
            this.BesoinId = besoinId;
        }
        public Ordinateur()
        {
            
        }

        public string Marque { get => marque; set => marque = value; }
        public string Cpu { get => cpu; set => cpu = value; }
        public string Ram { get => ram; set => ram = value; }
        public string Disque { get => disque; set => disque = value; }
        public string Ecran { get => ecran; set => ecran = value; }
        public int BesoinId { get => besoinId; set => besoinId = value; }
    }
}
