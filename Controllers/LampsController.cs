using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Illumination.Data;
using Illumination.Models;

namespace Illumination.Controllers
{
    public class LampsController : Controller
    {
        private readonly IlluminationContext _context;

        public LampsController(IlluminationContext context)
        {
            _context = context;
        }

        // GET: Lamps
        // GET: Movies
        public async Task<IActionResult> Index(string lampSize, string searchString)
        {
            if (_context.Lamp == null)
            {
                return Problem("Entity set 'IlluminationContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> sizeQuery = from m in _context.Lamp
                                            orderby m.Size
                                            select m.Size;
            var lamps = from m in _context.Lamp
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                lamps = lamps.Where(s => s.LampType!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(lampSize))
            {
                lamps = lamps.Where(x => x.Size == lampSize);
            }

            var lampSizeVM = new LampSizeViewModel
            {
                Sizes = new SelectList(await sizeQuery.Distinct().ToListAsync()),
                Lamps = await lamps.ToListAsync()
            };

            return View(lampSizeVM);
        }

        // GET: Lamps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await _context.Lamp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lamp == null)
            {
                return NotFound();
            }

            return View(lamp);
        }

        // GET: Lamps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lamps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LampType,Size,Design,Price,Powersource")] Lamp lamp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lamp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lamp);
        }

        // GET: Lamps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await _context.Lamp.FindAsync(id);
            if (lamp == null)
            {
                return NotFound();
            }
            return View(lamp);
        }

        // POST: Lamps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LampType,Size,Design,Price,Powersource")] Lamp lamp)
        {
            if (id != lamp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lamp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LampExists(lamp.Id))
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
            return View(lamp);
        }

        // GET: Lamps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await _context.Lamp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lamp == null)
            {
                return NotFound();
            }

            return View(lamp);
        }

        // POST: Lamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lamp = await _context.Lamp.FindAsync(id);
            if (lamp != null)
            {
                _context.Lamp.Remove(lamp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LampExists(int id)
        {
            return _context.Lamp.Any(e => e.Id == id);
        }
    }
}
