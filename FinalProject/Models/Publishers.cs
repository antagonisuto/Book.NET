using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Publishers : IValidatableObject
    {
        [Key]
        public int Pub_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Pub_name { get; set; }

        public virtual ICollection<Books> Books { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var pName = new[] { "Name" };
            if (Pub_name.Length > 40)
            {
                yield return new ValidationResult("Name cannot be such huge in length", pName);
            }
            
        }
    }
}
