using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Shawls_ReadyToWear.Data;
using Shawls_ReadyToWear.Models;

namespace Shawls_ReadyToWear.Controllers
{
    public class ShawlsController : Controller
    {
        private readonly Shawls_ReadyToWearContext _context;
        private readonly object Shawls;

        public ShawlsController(Shawls_ReadyToWearContext context)
        {
            _context = context;
        }

        // GET: Shawls
        // GET: Movies
        // GET: Movies
        public async Task<IActionResult> Index(string ShawlTitle, string searchString)
        {
            if (_context.Shawl == null)
            {
                return Problem("Entity set 'Shawl_ReadyToWear.Shawl is null.");
            }
            // Use LINQ to get list of genres. 

            IQueryable<string> ShawlQuery = from m in _context.Shawl

                                              orderby m.Title

                                              select m.Title;

            var Shawls = from m in _context.Shawl

                           select m;


            if (!String.IsNullOrEmpty(searchString))
            {
                Shawls = Shawls.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(ShawlTitle))

            {

                Shawls = Shawls.Where(x => x.Title == ShawlTitle);

            }



            var ShawlTitleViewModel = new ShawlTitleViewModel

            {

                Title = new SelectList(await ShawlQuery.Distinct().ToListAsync()),

                Shawls = await Shawls.ToListAsync()

            };

            return View(ShawlTitleViewModel);

        }

        // GET: Shawls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shawl = await _context.Shawl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shawl == null)
            {
                return NotFound();
            }

            return View(shawl);
        }

        // GET: Shawls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shawls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Material,Colour,Size,Price")] Shawl shawl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shawl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shawl);
        }

        // GET: Shawls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shawl = await _context.Shawl.FindAsync(id);
            if (shawl == null)
            {
                return NotFound();
            }
            return View(shawl);
        }

        // POST: Shawls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Material,Colour,Size,Price")] Shawl shawl)
        {
            if (id != shawl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shawl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShawlExists(shawl.Id))
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
            return View(shawl);
        }

        // GET: Shawls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shawl = await _context.Shawl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shawl == null)
            {
                return NotFound();
            }

            return View(shawl);
        }

        // POST: Shawls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shawl = await _context.Shawl.FindAsync(id);
            if (shawl != null)
            {
                _context.Shawl.Remove(shawl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShawlExists(int id)
        {
            return _context.Shawl.Any(e => e.Id == id);
        }
    }
}
