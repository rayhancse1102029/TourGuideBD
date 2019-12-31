using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TourGuideBD.Models
{
    public class Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Division ID")]
        public int DivisionId { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "maximum 50 char minimum 5 char")]
        public string DivisionName { get; set; }


        [DisplayName("Entry Date")]
        public DateTime EntryDate { get; set; }




        public List<Upazila> Upazila { get; set; }
        public List<Distric> Distric { get; set; }
        public List<VisitingPlace> VisitingPlace { get; set; }
        public List<AddNewPlaceByClient> AddNewPlaceByClient { get; set; }

    }
}
