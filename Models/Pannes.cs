using System.ComponentModel.DataAnnotations;


namespace ProjetGL.Models
{


    public class Pannes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateSignalement { get; set; } = DateTime.Now;

        public string Type { get; set; } // Matériel ou Logiciel

        public string Statut { get; set; } = "En attente"; // En attente, En cours, Résolu

        // Relation One-to-Many : Une panne peut avoir plusieurs constats
        public List<Constat> Constats { get; set; } = new List<Constat>();
    }
}
