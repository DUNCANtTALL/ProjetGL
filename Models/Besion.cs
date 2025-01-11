namespace ProjetGL.Models
{
    public class Besion
    {

        private int id;
        private string desc;
        public bool Status { get; set; }
        public List<Ordinateur> Ordinateurs { get; set; } = new List<Ordinateur>();
        public List<Imprimante> Imprimantes { get; set; } = new List<Imprimante>();
        public Besion(int id, string desc)
        {
            this.Id = id;
            this.Desc = desc;
        }

        public int Id { get => id; set => id = value; }
        public string Desc { get => desc; set => desc = value; }
    }

}
