using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAppData
{
    public class Cours
    {
        public int Id { get; set; }

        public string Code {  get; set; }

        [Required(ErrorMessage = "Nom obligatoire")]
        public string Nom {  get; set; }

        public Cours() { }

        public Cours(int id, string Code, string nom)
        {
            this.Id = id;
            this.Code = Code;
            this.Nom = nom;
        }
    }
}
