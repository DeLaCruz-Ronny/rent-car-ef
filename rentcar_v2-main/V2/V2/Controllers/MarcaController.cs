using Microsoft.AspNetCore.Mvc;
using V2.Models;

namespace V2.Controllers
{
    public class MarcaController : Controller
    {
        private readonly v2Context _context;

        public MarcaController(v2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Marca> ls = _context.Marcas.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Marca ma)
        {
            _context.Marcas.Add(ma);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Marca/Edit/{IdMarca:int}")]
        public IActionResult Edit(int? IdMarca)
        {
            if (IdMarca == null)
            {
                return NotFound();
            }
            var lib = _context.Marcas.Find(IdMarca);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Marca/Edit/{IdMarca:int}")]
        public IActionResult Edit(Marca ma)
        {
            //_context.Entry(cliente).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Marcas.Update(ma);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //return View(cli);
        }

        [Route("Marca/Delete/{IdMarca:int}")]
        public IActionResult Delete(int? IdMarca)
        {
            if (IdMarca == null)
            {
                return NotFound();
            }
            var lib = _context.Marcas.Find(IdMarca);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Marca/Delete/{IdMarca:int}")]
        public IActionResult Deletet(int? IdMarca)
        {
            var lib = _context.Marcas.Find(IdMarca);
            if (lib == null)
            {
                return NotFound();
            }
            _context.Marcas.Remove(lib);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
