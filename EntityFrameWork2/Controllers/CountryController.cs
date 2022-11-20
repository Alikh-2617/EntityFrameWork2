using EntityFrameWork2.Data;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWork2.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            return View(_context.Country.ToList());
        }
    }
}
