namespace ProjetGL.Models
{
    public class Livraison
    {
        public int id;
        public List<Ordinateur> ordinateurs;
        public List<Imprimante> imprimantes;

        public Livraison()
        {
            ordinateurs = new List<Ordinateur>();
            imprimantes = new List<Imprimante>(); 
        }

    }
}
