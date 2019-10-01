using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if(customer.BirthDay == null)
                return new ValidationResult("Birthday is requried.");

            var age = DateTime.Today.Year - customer.BirthDay.Value.Year;
            
                return(age >= 18) 
                    ? ValidationResult.Success
                    : new ValidationResult("Must at least be 18 years of age.");
        }
    }
}