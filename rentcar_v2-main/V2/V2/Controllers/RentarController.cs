using Microsoft.AspNetCore.Mvc;
using V2.Models;
using V2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace V2.Controllers
{
    public class RentarController : Controller
    {
        private readonly v2Context _context;

        public RentarController(v2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Rentar> ls = _context.Rentars.Include(c => c.oCliente).Include(ca => ca.oCategoria).Include(m => m.oModelo).Include(ma => ma.oMarca).ToList();
            return View(ls);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RentarVM oRentarVM = new RentarVM()
            {
                oRentar = new Rentar(),
                oListaCliente = _context.Clientes.Select(cliente => new SelectListItem()
                {
                    Text = cliente.Nombre,
                    Value = cliente.IdCliente.ToString()
                }).ToList(),
                oListaCategoria = _context.Categoria.Select(categoria => new SelectListItem()
                {
                    Text = categoria.Descripcion,
                    Value = categoria.IdCategoria.ToString()
                }).ToList(),
                oListaMarca = _context.Marcas.Select(marca => new SelectListItem()
                {
                    Text = marca.Descripcion,
                    Value = marca.IdMarca.ToString()
                }).ToList(),
                oListaModelo = _context.Modelos.Select(modelo => new SelectListItem()
                {
                    Text = modelo.Descripcion,
                    Value = modelo.IdModelo.ToString()
                }).ToList()
            };
            return View(oRentarVM);
        }

        [HttpPost]
        public IActionResult Create(RentarVM rentarVM)
        {
            _context.Rentars.Add(rentarVM.oRentar);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rentar");
        }

        [HttpGet]
        public IActionResult Edit(int IdRentar)
        {
            RentarVM oRentarVM = new RentarVM()
            {
                oRentar = new Rentar(),
                oListaCliente = _context.Clientes.Select(cliente => new SelectListItem()
                {
                    Text = cliente.Nombre,
                    Value = cliente.IdCliente.ToString()
                }).ToList(),
                oListaCategoria = _context.Categoria.Select(categoria => new SelectListItem()
                {
                    Text = categoria.Descripcion,
                    Value = categoria.IdCategoria.ToString()
                }).ToList(),
                oListaMarca = _context.Marcas.Select(marca => new SelectListItem()
                {
                    Text = marca.Descripcion,
                    Value = marca.IdMarca.ToString()
                }).ToList(),
                oListaModelo = _context.Modelos.Select(modelo => new SelectListItem()
                {
                    Text = modelo.Descripcion,
                    Value = modelo.IdModelo.ToString()
                }).ToList()
            };

            oRentarVM.oRentar = _context.Rentars.Find(IdRentar);

            return View(oRentarVM);
        }

        [HttpPost]
        public IActionResult Edit(RentarVM rentarVM)
        {
            _context.Rentars.Update(rentarVM.oRentar);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rentar");
        }

        [HttpGet]
        public IActionResult Delete(int IdRentar)
        {
            Rentar orentar = _context.Rentars.Include(c => c.oCliente).Where(c => c.IdRentar == IdRentar).Include(a => a.oCategoria).Where(s => s.IdRentar == IdRentar).
                Include(e => e.oMarca).Where(q => q.IdRentar == IdRentar).Include(r => r.oModelo).Where(g => g.IdRentar == IdRentar).FirstOrDefault();
            return View(orentar);
        }

        [HttpPost]
        public IActionResult Delete(Rentar OOrentar)
        {
            _context.Rentars.Remove(OOrentar);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rentar");
        }
    }
}
