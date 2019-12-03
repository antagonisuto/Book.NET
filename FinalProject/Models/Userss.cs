using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Models
{
    public class Userss : IdentityUser{

        [Required]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        [NotContainsDigits]
        public string FullName { get; set; }

        public virtual ICollection<BooksRequests> BooksRequests { get; set; }
        public virtual ICollection<BooksInventory> BooksInventories { get; set; }


        public class NotContainsDigitsAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    String stringValue = value.ToString();
                    if (stringValue.Any(char.IsDigit) == false)
                        return ValidationResult.Success;
                }

                return new ValidationResult("Name shouldn't contain digits");
            }
        }
    }
}