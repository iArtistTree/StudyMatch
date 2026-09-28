using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModelsLib
{
    public class Etudiant
    {
        public string Nom { get; set; }

        public Etudiant(string Nom)
        {
            this.Nom = Nom;
        }
    }
}
