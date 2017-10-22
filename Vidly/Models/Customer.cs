using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetters { get; set; }
        [Display(Name="Membership Type")]
        public MembershipType MembershipType { get; set; }
        [Display(Name ="Date of Birth")]
        public DateTime? Birthdate { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}