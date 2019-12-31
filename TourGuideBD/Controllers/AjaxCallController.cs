using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourGuideBD.Data;

namespace TourGuideBD.Controllers
{
    public class AjaxCallController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AjaxCallController(ApplicationDbContext context)
        {
            _context = context;
        }

        // get all distric

        [HttpGet]
        public IActionResult GetDistricList(int id)
        {
            var districtList = _context.Distric.Where(d => d.DivisionId == id).OrderBy(d => d.DistricName).ToList();

            return Json(districtList);
        }

        // get all place 

        [HttpGet]
        public IActionResult GetPlaceList(int id)
        {
            var placeList = _context.VisitingPlace.Where(d => d.DistricId == id).OrderBy(d => d.PlaceName).ToList();

            return Json(placeList);
        }
    }
}