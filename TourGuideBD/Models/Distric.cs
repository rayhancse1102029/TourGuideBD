using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TourGuideBD.Models
{
    public class Distric
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Distric ID")]
        public int DistricId { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "maximum 50 and minimum 3 char")]
        public string DistricName { get; set; }


        [Required]
        [DisplayName("Division Name")]
        public int DivisionId { get; set; }


        [DisplayName("Entry Date")]
        public DateTime EntryDate { get; set; }


        public Division Division { get; set; }

    }
}
