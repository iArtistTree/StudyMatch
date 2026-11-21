using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAppData
{
    public class Etudiant
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nom { get; set; }
        public virtual IList<GroupeEtude> Groupes { get; set; } = new List<GroupeEtude>();

        public Etudiant() { }
        public Etudiant(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }
    }
}
