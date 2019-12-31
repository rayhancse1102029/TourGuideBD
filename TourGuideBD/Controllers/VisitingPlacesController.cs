using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourGuideBD.Data;
using TourGuideBD.Models;

namespace TourGuideBD.Controllers
{
    public class VisitingPlacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitingPlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VisitingPlaces
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VisitingPlace.Include(v => v.Division).Include(v => v.PlaceType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VisitingPlaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitingPlace = await _context.VisitingPlace
                .Include(v => v.Division)
                .Include(v => v.PlaceType)
                .SingleOrDefaultAsync(m => m.PlaceId == id);
            if (visitingPlace == null)
            {
                return NotFound();
            }

            return View(visitingPlace);
        }

        // GET: VisitingPlaces/Create
        public IActionResult Create()
        {
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName");

            ViewData["DistricId"] = new SelectList(_context.Distric, "DistricId", "DistricName");

            ViewData["UpazilaId"] = new SelectList(_context.Upazila, "UpazilaId", "UpazilaName");

            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description");

            return View();
        }

        // POST: VisitingPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceId,PlaceName,PlaceTypeId,DivisionId,DistricId,UpazilaId,Image,Description,TouristEntryTime,EntryFee,ContactInfo,HowToGo")] VisitingPlace visitingPlace, IFormFile image)
        {
            if (ModelState.IsValid)
            {

                if (image.Length > 0)
                {
                    byte[] p1 = null;

                    using (var fs1 = image.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();

                        visitingPlace.Image = p1;

                    }
                }

                visitingPlace.EntryDate = DateTime.Now;

                _context.Add(visitingPlace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", visitingPlace.DivisionId);
            
            ViewData["DistricId"] = new SelectList(_context.Distric, "DistricId", "DistricName", visitingPlace.DistricId);

            ViewData["UpazilaId"] = new SelectList(_context.Upazila, "UpazilaId", "UpazilaName", visitingPlace.UpazilaId);
            
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description", visitingPlace.PlaceTypeId);

            return View(visitingPlace);
        }

        // GET: VisitingPlaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitingPlace = await _context.VisitingPlace.SingleOrDefaultAsync(m => m.PlaceId == id);
            if (visitingPlace == null)
            {
                return NotFound();
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", visitingPlace.DivisionId);
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description", visitingPlace.PlaceTypeId);
            return View(visitingPlace);
        }

        // POST: VisitingPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceId,PlaceName,PlaceTypeId,DivisionId,DistricId,UpazilaId,Image,Description,TouristEntryTime,EntryFee,ContactInfo,HowToGo,EntryDate")] VisitingPlace visitingPlace)
        {
            if (id != visitingPlace.PlaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitingPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitingPlaceExists(visitingPlace.PlaceId))
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
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", visitingPlace.DivisionId);
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description", visitingPlace.PlaceTypeId);
            return View(visitingPlace);
        }

        // GET: VisitingPlaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitingPlace = await _context.VisitingPlace
                .Include(v => v.Division)
                .Include(v => v.PlaceType)
                .SingleOrDefaultAsync(m => m.PlaceId == id);
            if (visitingPlace == null)
            {
                return NotFound();
            }

            return View(visitingPlace);
        }

        // POST: VisitingPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitingPlace = await _context.VisitingPlace.SingleOrDefaultAsync(m => m.PlaceId == id);
            _context.VisitingPlace.Remove(visitingPlace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitingPlaceExists(int id)
        {
            return _context.VisitingPlace.Any(e => e.PlaceId == id);
        }
    }
}
