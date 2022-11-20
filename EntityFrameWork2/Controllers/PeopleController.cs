using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameWork2.Data;
using EntityFrameWork2.Models;

namespace EntityFrameWork1.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            return View(_context.People.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonVM person)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                _context.People.Add(person);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Details(string id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var person = _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                PersonVM person = _context.People.Find(id);
                if (person != null)
                {
                    _context.People.Remove(person);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }



        public IActionResult Edit(string id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var person = _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,EfterName,age,PhoneNumber")] PersonVM person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }






        private bool PersonExists(string id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
