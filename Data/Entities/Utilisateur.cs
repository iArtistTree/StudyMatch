using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAppData.Entities
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Mdp { get; set; }

        public int? EtudiantId { get; set; }

        public virtual Etudiant? Etudiant { get; set; }

        public Utilisateur() { }
    }
}
