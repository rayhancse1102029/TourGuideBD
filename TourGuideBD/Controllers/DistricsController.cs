using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourGuideBD.Data;
using TourGuideBD.Models;

namespace TourGuideBD.Controllers
{
    public class DistricsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistricsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Districs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Distric.Include(d => d.Division);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Districs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distric = await _context.Distric
                .Include(d => d.Division)
                .SingleOrDefaultAsync(m => m.DistricId == id);
            if (distric == null)
            {
                return NotFound();
            }

            return View(distric);
        }

        // GET: Districs/Create
        public IActionResult Create()
        {
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName");
            return View();
        }

        // POST: Districs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistricId,DistricName,DivisionId")] Distric distric)
        {
            if (ModelState.IsValid)
            {
                distric.EntryDate = DateTime.Now;

                _context.Add(distric);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", distric.DivisionId);
            return View(distric);
        }

        // GET: Districs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distric = await _context.Distric.SingleOrDefaultAsync(m => m.DistricId == id);
            if (distric == null)
            {
                return NotFound();
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", distric.DivisionId);
            return View(distric);
        }

        // POST: Districs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistricId,DistricName,DivisionId,EntryDate")] Distric distric)
        {
            if (id != distric.DistricId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistricExists(distric.DistricId))
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
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", distric.DivisionId);
            return View(distric);
        }

        // GET: Districs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distric = await _context.Distric
                .Include(d => d.Division)
                .SingleOrDefaultAsync(m => m.DistricId == id);
            if (distric == null)
            {
                return NotFound();
            }

            return View(distric);
        }

        // POST: Districs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distric = await _context.Distric.SingleOrDefaultAsync(m => m.DistricId == id);
            _context.Distric.Remove(distric);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistricExists(int id)
        {
            return _context.Distric.Any(e => e.DistricId == id);
        }
    }
}
