using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedModelsLib.Dtos
{
    public class GroupeEtudeDto
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Sélectionnez  un cours")]
        public int CoursId { get; set; }

        [Required(ErrorMessage = "Sélectionnez  un jour")]
        [RegularExpression("^(Lundi|Mardi|Mercredi|Jeudi|Vendredi)$",
    ErrorMessage = "Jour invalide")]
        public string JourRetenu { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Sélectionnez  une disponibilité")]
        public int HeureRetenu { get; set; }

        public int? LocalId { get; set; }

        public bool Status { get; set; }
        public List<int> MembresIds { get; set; } = new List<int>();
        public List<string> MembresNoms {  get; set; } = new List<string>();
        public string LocalNom { get; set; }
        public string CoursCode { get; set; }
    }
}
