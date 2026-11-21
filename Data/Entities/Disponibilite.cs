using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAppData
{
    public class Disponibilite
    {
        public int Id { get; set; }

        public string Jour {  get; set; }

        public int CoursId {  get; set; }

        public List<int> Heures {  get; set; }

        public int EtudiantId { get; set; }
        
        public virtual Etudiant Etudiant { get; set; }
        public virtual Cours Cours { get; set; }

        public Disponibilite() { }
        public Disponibilite(int id, string Jour, int CoursCode, List<int> Heures, int EtudiantId)
        {
            this.Id = id;
            this.Jour = Jour;
            this.CoursId = CoursCode;
            this.Heures = Heures;
            this.EtudiantId = EtudiantId;
        }
    }
}
