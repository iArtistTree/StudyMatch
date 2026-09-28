using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModelsLib
{
    public class Disponibilite
    {
        public string Jour {  get; set; }
        public string CoursCode {  get; set; }
        public List<int> Heures {  get; set; }
        public string EtudiantNom { get; set; }

        public Disponibilite(string Jour, string CoursCode, List<int> Heures, string EtudiantNom)
        {
            this.Jour = Jour;
            this.CoursCode = CoursCode;
            this.Heures = Heures;
            this.EtudiantNom = EtudiantNom;
        }
    }
}
