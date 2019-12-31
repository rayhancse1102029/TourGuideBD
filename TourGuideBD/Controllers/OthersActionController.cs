using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TourGuideBD.Data;
using TourGuideBD.Models;

namespace TourGuideBD.Controllers
{
    public class OthersActionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OthersActionController(ApplicationDbContext context)
        {
            _context = context;
        }

        //  Visiting Place Data Show

        public IActionResult PlaceDataShow()
        {
            return View();
        }

        // Home controller search function

        [HttpPost]
        public IActionResult Search(VisitingPlace visitingPlace)
        {

            IQueryable<VisitingPlace> vp = from item in _context.VisitingPlace
                                            where visitingPlace.PlaceId == item.PlaceId
                                            select item;

            ViewBag.d = vp;

            return View("PlaceDataShow");
        }
    }
}