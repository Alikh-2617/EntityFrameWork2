
using EntityFrameWork2.Data;
using EntityFrameWork2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWork1.Controllers
{
    public class CitysController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CitysController(ApplicationDbContext context)
        {
            _context = context;

        }


        public IActionResult Index()
        {
            return View(_context.City.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CityVM city)
        {
            if (ModelState.IsValid)
            {
                _context.City.Add(city);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string name)
        {
            var city = _context.City.Find(name);
            if (city != null)
            {
                _context.City.Remove(city);
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}
