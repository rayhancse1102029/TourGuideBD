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
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Comment ID")]
        public int CommentId { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "maximum 50 char and minimum 3 char")]
        [DisplayName("Username")]
        public string SenderName { get; set; }


        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "maximum 50 char and minimum 3 char")]
        [DisplayName("Comment")]
        public string CommentText { get; set; }


        public bool IsSeen { get; set; } = false;


        [DisplayName("Entry Date")]
        public DateTime CommentTime { get; set; }
    }
}
