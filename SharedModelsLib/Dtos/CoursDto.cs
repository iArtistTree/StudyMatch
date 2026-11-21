using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedModelsLib.Dtos
{
    public class CoursDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code est requis")]
        [StringLength(20, ErrorMessage = "20 caractères maximum")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100, ErrorMessage = "100 caractères maximum")]
        public string Nom { get; set; } = string.Empty;
    }
}
