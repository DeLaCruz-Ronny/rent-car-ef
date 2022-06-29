using Microsoft.AspNetCore.Mvc;
using V2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace V2.Controllers
{
    public class ClientesController : Controller
    {
        private readonly v2Context _context;

        public ClientesController(v2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Cliente> ls = _context.Clientes.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Clientes/Edit/{IdCliente:int}")]
        public IActionResult Edit(int? IdCliente)
        {
            if (IdCliente == null)
            {
                return NotFound();
            }
            var lib = _context.Clientes.Find(IdCliente);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Clientes/Edit/{IdCliente:int}")]
        public IActionResult Edit(Cliente cli)
        {
            //_context.Entry(cliente).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Clientes.Update(cli);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //return View(cli);
        }

        [Route("Clientes/Delete/{IdCliente:int}")]
        public IActionResult Delete(int? IdCliente)
        {
            if (IdCliente == null)
            {
                return NotFound();
            }
            var lib = _context.Clientes.Find(IdCliente);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Clientes/Delete/{IdCliente:int}")]
        public IActionResult Deletet(int? IdCliente)
        {
            var lib = _context.Clientes.Find(IdCliente);
            if (lib == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(lib);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
