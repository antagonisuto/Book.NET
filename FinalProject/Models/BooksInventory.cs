using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class BooksInventory
    {
        public string Book_id { get; set; }
        [ForeignKey("Book_id")]
        public virtual Books Book { get; set; }

        public string User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual Userss  User { get; set; }

    }
}
