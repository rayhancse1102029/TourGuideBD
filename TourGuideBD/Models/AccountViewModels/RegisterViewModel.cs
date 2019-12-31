using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourGuideBD.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "maximum 30 char and minimum 3 char")]
        [DisplayName("Username")]
        public string RegClientName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [DisplayName("Registration Date")]
        public DateTime RegDate { get; set; }
    }
}
