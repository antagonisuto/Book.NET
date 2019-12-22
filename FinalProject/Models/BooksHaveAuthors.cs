using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class BooksHaveAuthors
    {
        public string Book_id { get; set; }
        [ForeignKey("Book_id")]
        public virtual Books Book { get; set; }

        public string Author_id { get; set; }
        [ForeignKey("Author_id")]
        public virtual Authors Authors { get; set; }
    }
}
