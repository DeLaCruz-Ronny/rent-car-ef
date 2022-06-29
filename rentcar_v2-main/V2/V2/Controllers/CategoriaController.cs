using Microsoft.AspNetCore.Mvc;
using V2.Models;

namespace V2.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly v2Context _context;

        public CategoriaController(v2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Categorium> ls = _context.Categoria.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categorium cat)
        {
            _context.Categoria.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Categoria/Edit/{IdCategoria:int}")]
        public IActionResult Edit(int? IdCategoria)
        {
            if (IdCategoria == null)
            {
                return NotFound();
            }
            var lib = _context.Categoria.Find(IdCategoria);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Categoria/Edit/{IdCategoria:int}")]
        public IActionResult Edit(Categorium cat)
        {
            //_context.Entry(cliente).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Categoria.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //return View(cli);
        }

        [Route("Categoria/Delete/{IdCategoria:int}")]
        public IActionResult Delete(int? IdCategoria)
        {
            if (IdCategoria == null)
            {
                return NotFound();
            }
            var lib = _context.Categoria.Find(IdCategoria);

            if (lib == null)
            {
                return NotFound();
            }

            return View(lib);
        }

        [HttpPost]
        [Route("Categoria/Delete/{IdCategoria:int}")]
        public IActionResult Deletet(int? IdCategoria)
        {
            var lib = _context.Categoria.Find(IdCategoria);
            if (lib == null)
            {
                return NotFound();
            }
            _context.Categoria.Remove(lib);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
