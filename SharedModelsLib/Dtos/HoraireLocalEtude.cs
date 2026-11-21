using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedModelsLib.Dtos
{
    public class HoraireLocalDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Sélectionnez un jour valide")]
        [RegularExpression("^(Lundi|Mardi|Mercredi|Jeudi|Vendredi)$", ErrorMessage = "Jour invalide")]
        public string Jour { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Sélectionnez  une disponibilité")]
        public int Heure { get; set; }

        public int LocalId { get; set; }
    }
}
