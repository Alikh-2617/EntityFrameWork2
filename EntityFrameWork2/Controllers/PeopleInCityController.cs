using System.Drawing.Text;
using EntityFrameWork2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWork2.Controllers
{
    public class PeopleInCityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleInCityController(ApplicationDbContext context)
        {
            _context = context;
        }


        // vi ska hitta personerna som bor i den stad 
        public IActionResult Index(string name)
        {
            // gå in i City lista vilken har en people lista , i den people lista hitta personer som har samma City värde
            var peopleInThisCity = _context.City.Include(x => x.people).FirstOrDefault(x => x.Name == name);


            // skicka även City's namn till View
            ViewBag.CityName = peopleInThisCity.Name;

            // vi skickar bara lista av personer 
            return View(peopleInThisCity.people);
        }

        public IActionResult AddPersonToCity()
        {
            ViewBag.People = new SelectList(_context.People, "Id", "Name");
            ViewBag.Citys = new SelectList(_context.City, "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonToCity(string id, string Name)
        {
            //            
            // vi kollar om 
            var city = _context.City.Include(x => x.people).FirstOrDefault(x => x.Name == Name);

            var person = _context.People.Find(id);

            if (!city.people.Any(c => c.Id == id))
            {
                city.people.Add(person);
                _context.SaveChanges();
            }
            else
            {
                // för att vi kommer till baka till samma View OCH den person funnits i den city innan ,
                // så vi skicka om samma Viewbag till Viewn MED en MESSAGE 
                ViewBag.People = new SelectList(_context.People.Where(x => x.Id != id), "Id", "Name");
                ViewBag.Citys = new SelectList(_context.City, "Name", "Name");
                ViewBag.Message = $"Staden har den person => Namn : {person.Name} = ID :{person.Id}";
                return View();
            }

            return RedirectToAction("Index", new { name = Name });
        }


        public IActionResult DeletePeople(string personId, string cityName)
        {
            var city = _context.City.Include(x => x.people).FirstOrDefault(x => x.Name == cityName);
            var person = _context.People.Find(personId);

            if (person != null)
            {
                city.people.Remove(person);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { id = personId });
        }

    }
}
