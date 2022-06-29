using Microsoft.AspNetCore.Mvc;
using V2.Models;

namespace V2.Controllers
{
    public class ModeloController : Controller
    {
        private readonly v2Context _context;

        public ModeloController(v2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Modelo> ls = _context.Modelos.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Modelo mo)
        {
            _context.Modelos.Add(mo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Modelo/Edit/{IdModelo:int}")]
        public IActionResult Edit(int? IdModelo)
        {
            if (IdModelo == null)
            {
                return NotFound();
            }
            var lib = _context.Modelos.Find(IdModelo);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Modelo/Edit/{IdModelo:int}")]
        public IActionResult Edit(Modelo mo)
        {
            //_context.Entry(cliente).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Modelos.Update(mo);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //return View(cli);
        }

        [Route("Modelo/Delete/{IdModelo:int}")]
        public IActionResult Delete(int? IdModelo)
        {
            if (IdModelo == null)
            {
                return NotFound();
            }
            var lib = _context.Modelos.Find(IdModelo);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Modelo/Delete/{IdModelo:int}")]
        public IActionResult Deletet(int? IdModelo)
        {
            var lib = _context.Modelos.Find(IdModelo);
            if (lib == null)
            {
                return NotFound();
            }
            _context.Modelos.Remove(lib);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
