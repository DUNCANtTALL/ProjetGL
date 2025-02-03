using ProjetGL.Buisness;
using System.ComponentModel.DataAnnotations;

namespace ProjetGL.Models
{
    public class AppelD_offre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "La date de début est obligatoire.")]
        public DateTime DateDebut { get; set; }

        [Required(ErrorMessage = "La date de fin est obligatoire.")]
        public DateTime DateFin { get; set; }

        [Required(ErrorMessage = "La description est obligatoire.")]
        public string Description { get; set; }
    }
}
