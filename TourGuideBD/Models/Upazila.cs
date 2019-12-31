using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TourGuideBD.Models
{
    public class Upazila
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Upazila ID")]
        public int UpazilaId { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "maximum 50 char and minimum 3 char")]
        public string UpazilaName { get; set; }


        [Required]
        [DisplayName("Distric Name")]
        public int DistricId { get; set; }


        [Required]
        [DisplayName("Division Name")]
        public int DivisionId { get; set; }


        [DisplayName("Entry Date")]
        public DateTime EntryDate { get; set; }


        public Division Division { get; set; }

    }
}
