using System;
using System.Collections.Generic;

namespace V2.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Rentars = new HashSet<Rentar>();
        }

        public int IdMarca { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Rentar> Rentars { get; set; }
    }
}
