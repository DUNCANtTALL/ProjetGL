using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetGL.Models
{
    public class Constat
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "L'explication est obligatoire.")]
        public string Explication { get; set; }

        [Required(ErrorMessage = "La date du constat est obligatoire.")]
        public DateTime DateConstat { get; set; } = DateTime.Now; // Valeur par défaut

        [Required(ErrorMessage = "La fréquence est obligatoire.")]
        public string Frequence { get; set; }

        [Required(ErrorMessage = "L'ordre est obligatoire.")]
        public string Ordre { get; set; }

        public int PanneId { get; set; } // Doit être bien assigné
    }
}
