using System;
using System.Collections.Generic;

namespace V2.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Rentars = new HashSet<Rentar>();
        }

        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Rentar> Rentars { get; set; }
    }
}
