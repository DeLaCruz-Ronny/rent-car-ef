using Microsoft.AspNetCore.Mvc.Rendering;

namespace V2.Models.ViewModels
{
    public class RentarVM
    {
        public Rentar oRentar { get; set; }

        public List<SelectListItem> oListaCliente { get; set; }
        public List<SelectListItem> oListaCategoria { get; set; }
        public List<SelectListItem> oListaMarca { get; set; }
        public List<SelectListItem> oListaModelo { get; set; }

    }
}
