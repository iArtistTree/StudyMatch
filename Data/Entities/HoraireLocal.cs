using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAppData
{
    public class HoraireLocal
    {
        public int Id { get; set; }

        [Required]
        public string Jour { get; set; } = string.Empty;

        [Range(8, 15)]
        public int Heure { get; set; }

        public int LocalId { get; set; }
        public virtual Local Local { get; set; } = null!;
    }
}
