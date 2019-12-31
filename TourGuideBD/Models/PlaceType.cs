using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TourGuideBD.Models
{
    public class PlaceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaceTypeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "maximum 100 char and minimum 3 char")]
        public string PlaceTypeName { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "maximum 300 char and minimum 3 char")]
        public string Description { get; set; }


        [DisplayName("Entry Date")]
        public DateTime EntryDate { get; set; }




        public List<VisitingPlace> VisitingPlace { get; set; }
        public List<AddNewPlaceByClient> AddNewPlaceByClient { get; set; }

    }
}
