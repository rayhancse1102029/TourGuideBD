using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TourGuideBD.Models
{
    public class AddNewPlaceByClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Place ID")]
        public int PlaceByClientId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "maximum 200 char and minimum 3 char ")]
        [DisplayName("Place Name")]
        public string PlaceName { get; set; }


        [Required]
        [DisplayName("Place Type")]
        public int PlaceTypeId { get; set; }


        [Required]
        [DisplayName("Division Name")]
        public int DivisionId { get; set; }


        [Required]
        [DisplayName("Distric Name")]
        public int DistricId { get; set; }


        [Required]
        [DisplayName("Upazila Name")]
        public int UpazilaId { get; set; }


        [Required]
        public byte[] Image { get; set; }

        [Required]
        [DisplayName("Image")]
        [StringLength(2000, MinimumLength = 100, ErrorMessage = "maximum 2000 char and minimum 100 char")]
        public string Description { get; set; }



        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "maximum 500 char and minimum 5 char")]
        [DisplayName("Opening and Close Time")]
        public string TouristEntryTime { get; set; }


        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "maximum 500 char and minimum 5 char")]
        [DisplayName("Entry Fee")]
        public string EntryFee { get; set; }


        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "maximum 500 char and minimum 5 char")]
        [DisplayName("Contact Information")]
        public string ContactInfo { get; set; }


        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "maximum 1000 char and minimum 10 char")]
        [DisplayName("How To Go")]
        public string HowToGo { get; set; }


        public bool IsSeen { get; set; } = false;

        [Required]
        [DisplayName("Username")]
        public string SenderName { get; set; }


        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "please enter a valid phone number")]
        public int Phone { get; set; }

        [DisplayName("Entry Date")]
        public DateTime EntryDate { get; set; }


        public PlaceType PlaceType { get; set; }
        public Division Division { get; set; }
    }
}
