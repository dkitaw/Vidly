using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Minimum18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customre = (Customer)validationContext.ObjectInstance;
            if (customre.MembershipTypeId==MembershipType.PayAsYouGo || customre.MembershipTypeId == MembershipType.UnKnown)
                return ValidationResult.Success;
            if (customre.Birthdate == null)
                return new ValidationResult("Birhtdate is required");
            var age = DateTime.Today.Year - customre.Birthdate.Value.Year;
            return (age >= 18 
                ? ValidationResult.Success
                : new ValidationResult("customer should be atlest 18 year old to go on membership"));

        }

    }
}