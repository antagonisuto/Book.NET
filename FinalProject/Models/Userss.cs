using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Models
{
    public class Userss
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Remote(action: "VerifyUsername", controller: "Userss")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        [NotContainsDigits]
        public string FullName { get; set; }

        public int? Role_id { get; set; }
        [ForeignKey("Role_id")]
        public virtual Roles Role { get; set; }

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