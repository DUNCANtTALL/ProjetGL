namespace ProjetGL.Models
{
    public class AppelD_offre
    {
        private DateTime dateDebut;
        private DateTime dateFin;
        private string description;

        public AppelD_offre(DateTime dateDebut, DateTime dateFin, string description)
        {
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.description = description;
        }

        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime DateFin { get => dateFin; set => dateFin = value; }
        public string Description { get => description; set => description = value; }
    }
}
