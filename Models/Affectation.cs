namespace ProjetGL.Models
{
    public class Affectation
    {
       
            public int Id { get; set; }
            public int RessourceId { get; set; } 
            public Ordinateur ordinateur{ get; set; }
            public Imprimante imprimante { get; set;  }
            public int DepartementId { get; set; }  
       

    }
}
