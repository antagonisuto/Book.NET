using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Authors
    {
        [Key]
        public string Author_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Author_name { get; set; }

        public virtual ICollection<BooksHaveAuthors> BooksHaveAuthors { get; set; }
    }
}
