using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedModelsLib.Dtos
{
    public class LocalDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "20 caractères maximum")]
        public string Nom { get; set; } = string.Empty;

        [Range(2, int.MaxValue, ErrorMessage = "Capacité de 2 au minimum")]
        public int Capacite { get; set; }
    }
}
