using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedModelsLib.Dtos
{
    public class EtudiantDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Entrez un nom")]
        [StringLength(50, ErrorMessage = "50 caractères maximum")]
        [RegularExpression(@"^[\p{L} '\-]+$", ErrorMessage = "Le nom ne peut contenir que des lettres")]
        public string Nom { get; set; } = string.Empty;
    }
}
