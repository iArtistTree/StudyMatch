using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedModelsLib.Dtos
{
    public class DisponibiliteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sélectionnez un jour valide")]
        [RegularExpression("^(Lundi|Mardi|Mercredi|Jeudi|Vendredi)$", ErrorMessage = "Jour invalide")]
        public string Jour { get; set; } = string.Empty;


        [Range(1, int.MaxValue, ErrorMessage = "Sélectionnez  un cours")]
        public int CoursId { get; set; }

        [MinLength(1, ErrorMessage = "Sélectionnez au moins une disponibilité")]
        public List<int> Heures { get; set; } = new List<int>();

        [Range(0, int.MaxValue, ErrorMessage = "Sélectionnez  un étudiant")]
        public int EtudiantId { get; set; }
    }
}
