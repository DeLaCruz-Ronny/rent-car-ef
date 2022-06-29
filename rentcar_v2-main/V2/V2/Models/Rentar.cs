using System;
using System.Collections.Generic;

namespace V2.Models
{
    public partial class Rentar
    {
        public int IdRentar { get; set; }
        public int? IdCliente { get; set; }
        public int? IdMarca { get; set; }
        public int? IdModelo { get; set; }
        public int? IdCategoria { get; set; }
        public DateTime? FechaRentado { get; set; }
        public DateTime? FechaRetorno { get; set; }

        public virtual Categorium? oCategoria { get; set; }
        public virtual Cliente? oCliente { get; set; }
        public virtual Marca? oMarca { get; set; }
        public virtual Modelo? oModelo { get; set; }
    }
}
