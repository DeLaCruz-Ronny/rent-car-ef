using System;
using System.Collections.Generic;

namespace V2.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Rentars = new HashSet<Rentar>();
        }

        public int IdModelo { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Rentar> Rentars { get; set; }
    }
}
