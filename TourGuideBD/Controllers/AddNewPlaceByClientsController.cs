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
    public class AddNewPlaceByClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddNewPlaceByClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddNewPlaceByClients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AddNewPlaceByClient.Include(a => a.Division).Include(a => a.PlaceType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AddNewPlaceByClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewPlaceByClient = await _context.AddNewPlaceByClient
                .Include(a => a.Division)
                .Include(a => a.PlaceType)
                .SingleOrDefaultAsync(m => m.PlaceByClientId == id);
            if (addNewPlaceByClient == null)
            {
                return NotFound();
            }

            return View(addNewPlaceByClient);
        }

        // GET: AddNewPlaceByClients/Create
        public IActionResult Create()
        {
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName");
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description");
            return View();
        }

        // POST: AddNewPlaceByClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceByClientId,PlaceName,PlaceTypeId,DivisionId,DistricId,UpazilaId,Image,Description,TouristEntryTime,EntryFee,ContactInfo,HowToGo,IsSeen,SenderName,Email,Phone,EntryDate")] AddNewPlaceByClient addNewPlaceByClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addNewPlaceByClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", addNewPlaceByClient.DivisionId);
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description", addNewPlaceByClient.PlaceTypeId);
            return View(addNewPlaceByClient);
        }

        // GET: AddNewPlaceByClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewPlaceByClient = await _context.AddNewPlaceByClient.SingleOrDefaultAsync(m => m.PlaceByClientId == id);
            if (addNewPlaceByClient == null)
            {
                return NotFound();
            }
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", addNewPlaceByClient.DivisionId);
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description", addNewPlaceByClient.PlaceTypeId);
            return View(addNewPlaceByClient);
        }

        // POST: AddNewPlaceByClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceByClientId,PlaceName,PlaceTypeId,DivisionId,DistricId,UpazilaId,Image,Description,TouristEntryTime,EntryFee,ContactInfo,HowToGo,IsSeen,SenderName,Email,Phone,EntryDate")] AddNewPlaceByClient addNewPlaceByClient)
        {
            if (id != addNewPlaceByClient.PlaceByClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addNewPlaceByClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddNewPlaceByClientExists(addNewPlaceByClient.PlaceByClientId))
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
            ViewData["DivisionId"] = new SelectList(_context.Division, "DivisionId", "DivisionName", addNewPlaceByClient.DivisionId);
            ViewData["PlaceTypeId"] = new SelectList(_context.PlaceType, "PlaceTypeId", "Description", addNewPlaceByClient.PlaceTypeId);
            return View(addNewPlaceByClient);
        }

        // GET: AddNewPlaceByClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewPlaceByClient = await _context.AddNewPlaceByClient
                .Include(a => a.Division)
                .Include(a => a.PlaceType)
                .SingleOrDefaultAsync(m => m.PlaceByClientId == id);
            if (addNewPlaceByClient == null)
            {
                return NotFound();
            }

            return View(addNewPlaceByClient);
        }

        // POST: AddNewPlaceByClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addNewPlaceByClient = await _context.AddNewPlaceByClient.SingleOrDefaultAsync(m => m.PlaceByClientId == id);
            _context.AddNewPlaceByClient.Remove(addNewPlaceByClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddNewPlaceByClientExists(int id)
        {
            return _context.AddNewPlaceByClient.Any(e => e.PlaceByClientId == id);
        }
    }
}
