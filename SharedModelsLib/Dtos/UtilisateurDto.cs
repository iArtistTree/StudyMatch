using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedModelsLib.Dtos
{
    public class UtilisateurDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Entrez un email")]
        [EmailAddress(ErrorMessage = "Entrez un email valide")]
        [StringLength(50, ErrorMessage = "50 caractères maximum")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Entrez un mot de passe")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Le mot de passe doit contenir entre 8 et 100 caractères")]
        public string Mdp { get; set; }

        public int? EtudiantId { get; set; }
    }
}
