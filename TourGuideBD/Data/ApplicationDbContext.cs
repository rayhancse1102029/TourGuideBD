using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TourGuideBD.Models;

namespace TourGuideBD.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<TourGuideBD.Models.Division> Division { get; set; }

        public DbSet<TourGuideBD.Models.Distric> Distric { get; set; }

        public DbSet<TourGuideBD.Models.Upazila> Upazila { get; set; }

        public DbSet<TourGuideBD.Models.PlaceType> PlaceType { get; set; }

        public DbSet<TourGuideBD.Models.AddNewPlaceByClient> AddNewPlaceByClient { get; set; }

        public DbSet<TourGuideBD.Models.VisitingPlace> VisitingPlace { get; set; }

        public DbSet<TourGuideBD.Models.Comment> Comment { get; set; }
    }
}
