using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STGApplication.Data;
using STGApplication.Models;

namespace STGApplication.Controllers
{
    public class AnimalController : Controller
    {
        private readonly DBContext _context;

        public AnimalController(DBContext context)
        {
            _context = context;
        }
        //GET: Animals
        public async Task<IActionResult> Index(string buscar, string actualOrder, int? numpag, string actualFilter) {

            var animals = from animal in _context.animal select animal;
            if (buscar != null)
                numpag = 1;
            else
                buscar = actualFilter;

            if (!String.IsNullOrEmpty(buscar)){
                animals = animals.Where(a => a.Name!.Contains(buscar));
            }
            ViewData["ActualOrder"] = actualOrder;
            ViewData["ActualFilter"] = actualFilter;

            ViewData["FilterName"] = String.IsNullOrEmpty(actualOrder) ? "NameDescendent" : "";
            ViewData["FilterBreed"] = String.IsNullOrEmpty(actualOrder) ? "BreedDescendent" : "BreedAscendent";
            ViewData["FilterSex"] = String.IsNullOrEmpty(actualOrder) ? "SexDescendent" : "SexAscendent";
            ViewData["FilterPrice"] = String.IsNullOrEmpty(actualOrder) ? "PriceDescendent" : "PriceAscendent";
            ViewData["FilterStatus"] = String.IsNullOrEmpty(actualOrder) ? "StatusDescendent" : "StatusAscendent";
            ViewData["FilterDate"] = actualOrder == "DateAscendent" ? "DateDescendent" : "DateAscendent";

            switch (actualOrder)
            {
                case "NameDescendent":
                    animals = animals.OrderByDescending(animal => animal.Name);
                    break;
                case "BreedDescendent":
                    animals = animals.OrderByDescending(animal => animal.Breed);
                    break;
                case "BreedAscendent":
                    animals = animals.OrderBy(animal => animal.Breed);
                    break;
                case "SexDescendent":
                    animals = animals.OrderByDescending(animal => animal.Sex);
                    break;
                case "SexAscendent":
                    animals = animals.OrderBy(animal => animal.Sex);
                    break;
                case "PriceDescendent":
                    animals = animals.OrderByDescending(animal => animal.Price);
                    break;
                case "PriceAscendent":
                    animals = animals.OrderBy(animal => animal.Price);
                    break;
                case "StatusDescendent":
                    animals = animals.OrderByDescending(animal => animal.Status);
                    break;
                case "StatusAscendent":
                    animals = animals.OrderBy(animal => animal.Status);
                    break;
                case "DateDescendent":
                    animals = animals.OrderByDescending(animal => animal.BirthDate);
                    break;
                case "DateAscendent":
                    animals = animals.OrderBy(animal => animal.BirthDate);
                    break;

                default:
                    animals = animals.OrderBy(animal => animal.Name);
                    break;
            }
            decimal totalSum = animals.Sum(a => a.Price);
            ViewBag.TotalPrice = totalSum;

            int cantData = 10;

            return View(await Pagination<Animal>.MakePagination(animals.AsNoTracking(), numpag??1, cantData));
        }

        // GET: Animal
        //public async Task<IActionResult> Index()
        //{
        //      return _context.animal != null ? 
        //                  View(await _context.animal.ToListAsync()) :
        //                  Problem("Entity set 'DBContext.animal'  is null.");
        //}

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.animal == null)
            {
                return NotFound();
            }

            var animal = await _context.animal
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId,Name,Breed,BirthDate,Sex,Price,Status")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.animal == null)
            {
                return NotFound();
            }

            var animal = await _context.animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalId,Name,Breed,BirthDate,Sex,Price,Status")] Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalId))
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
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.animal == null)
            {
                return NotFound();
            }

            var animal = await _context.animal
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.animal == null)
            {
                return Problem("Entity set 'DBContext.animal'  is null.");
            }
            var animal = await _context.animal.FindAsync(id);
            if (animal != null)
            {
                _context.animal.Remove(animal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
          return (_context.animal?.Any(e => e.AnimalId == id)).GetValueOrDefault();
        }
    }
}
