using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModelsLib
{
    public class Local
    {
        public string Nom { get; set; }
        public Dictionary<string, List<int>> Horaires { get; set; }

        public Local(string nom, Dictionary<string, List<int>> horaires)
        {
            this.Nom = nom;
            this.Horaires = horaires;
        }
    }
}