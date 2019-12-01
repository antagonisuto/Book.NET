using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Books
    {
        [Key]
        public string Book_id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Book_title { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Book_page { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Book_pub { get; set; }

        [Required]
        [StringLength(100)]
        public string Book_shortDec { get; set; }

        [Required]
        [StringLength(200)]
        public string Book_dec { get; set; }

        
        public string Pub_id { get; set; }
        [ForeignKey("Pub_id")]
        public virtual Publishers Publishers { get; set; }

        public virtual ICollection<BooksRequests> BooksRequests { get; set; }
        public virtual ICollection<BooksHaveAuthors> BooksHaveAuthors { get; set; }
        public virtual ICollection<BooksInventory> BooksInventories { get; set; }
    }
}
