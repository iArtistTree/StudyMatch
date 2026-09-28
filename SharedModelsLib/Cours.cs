using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModelsLib
{
    public class Cours
    {
        public string Code {  get; set; }
        public string Nom {  get; set; }

        public Cours(string Code, string nom)
        {
            this.Code = Code;
            this.Nom = nom;
        }
    }
}
