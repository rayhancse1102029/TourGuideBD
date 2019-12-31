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
    public class UpazilasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpazilasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Upazilas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Upazila.Include(u => u.Division);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Upazilas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazila
                .Include(u => u.Division)
                .SingleOrDefaultAsync(m => m.UpazilaId == id);
            if (upazila == null)
            {
                return NotFound();
            }

            return View(upazila);
        }

        // GET: Upazilas/Create
        public IActionResult Create()
        {
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName");

            ViewData["DistricId"] = new SelectList(_context.Distric, "DistricId", "DistricName");

            return View();
        }

        // POST: Upazilas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UpazilaId,UpazilaName,DistricId,DivisionId")] Upazila upazila)
        {
            if (ModelState.IsValid)
            {
                upazila.EntryDate = DateTime.Now;

                _context.Add(upazila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", upazila.DivisionId);
            return View(upazila);
        }

        // GET: Upazilas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazila.SingleOrDefaultAsync(m => m.UpazilaId == id);
            if (upazila == null)
            {
                return NotFound();
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", upazila.DivisionId);
            return View(upazila);
        }

        // POST: Upazilas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UpazilaId,UpazilaName,DistricId,DivisionId,EntryDate")] Upazila upazila)
        {
            if (id != upazila.UpazilaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upazila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpazilaExists(upazila.UpazilaId))
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
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", upazila.DivisionId);
            return View(upazila);
        }

        // GET: Upazilas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazila
                .Include(u => u.Division)
                .SingleOrDefaultAsync(m => m.UpazilaId == id);
            if (upazila == null)
            {
                return NotFound();
            }

            return View(upazila);
        }

        // POST: Upazilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upazila = await _context.Upazila.SingleOrDefaultAsync(m => m.UpazilaId == id);
            _context.Upazila.Remove(upazila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpazilaExists(int id)
        {
            return _context.Upazila.Any(e => e.UpazilaId == id);
        }
    }
}
