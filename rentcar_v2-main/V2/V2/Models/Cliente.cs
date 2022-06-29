using System;
using System.Collections.Generic;

namespace V2.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Rentars = new HashSet<Rentar>();
        }

        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Rentar> Rentars { get; set; }
    }
}
