using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData
{
    public class Local
    {
        public int Id { get; set; }


        public string Nom { get; set; } = string.Empty;

        public int Capacite { get; set; }

        public virtual IList<HoraireLocal> Horaires { get; set; } = new List<HoraireLocal>();

        public Local() { }
    }
}