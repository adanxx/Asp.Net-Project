using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Studio_Line.Models;
using System.ComponentModel.DataAnnotations;

namespace Studio_Line.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public String Email { get; set; }

        [Display(Name=" State Date of Your Birth")]
        public DateTime? Birthday { get; set; }

        public bool IsSubcriptedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage =" Membershiptype is Required")]
        [Display(Name = " Choose Membership Subcription Type ")]
        public byte MembershipTypeId { get; set; }
    }
}