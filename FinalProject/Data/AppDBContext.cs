using System;
using System.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class AppDBContext : IdentityDbContext<Userss>
    {

        public AppDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Userss> Userss { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        public DbSet<BooksHaveAuthors> BooksHaveAuthors { get; set; }
        public DbSet<BooksInventory> BooksInventories { get; set; }
        public DbSet<BooksRequests> BooksRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //BooksRequests//
            modelBuilder.Entity<BooksRequests>()
                .HasKey(t => new { t.Book_id, t.User_id });

            modelBuilder.Entity<BooksRequests>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.BooksRequests)
                .HasForeignKey(sc => sc.User_id);

            modelBuilder.Entity<BooksRequests>()
                .HasOne(sc => sc.Book)
                .WithMany(c => c.BooksRequests)
                .HasForeignKey(sc => sc.Book_id);
            //BooksRequests//

            //BooksHaveAuthors//
            modelBuilder.Entity<BooksHaveAuthors>()
                .HasKey(t => new { t.Author_id, t.Book_id });

            modelBuilder.Entity<BooksHaveAuthors>()
                .HasOne(sc => sc.Book)
                .WithMany(s => s.BooksHaveAuthors)
                .HasForeignKey(sc => sc.Book_id);

            modelBuilder.Entity<BooksHaveAuthors>()
                .HasOne(sc => sc.Authors)
                .WithMany(c => c.BooksHaveAuthors)
                .HasForeignKey(sc => sc.Author_id);
            //BooksHaveAuthors//

            //BookInventory//
            modelBuilder.Entity<BooksInventory>()
                .HasKey(t => new { t.Book_id, t.User_id });

            modelBuilder.Entity<BooksInventory>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.BooksInventories)
                .HasForeignKey(sc => sc.User_id);

            modelBuilder.Entity<BooksInventory>()
                .HasOne(sc => sc.Book)
                .WithMany(c => c.BooksInventories)
                .HasForeignKey(sc => sc.Book_id);
            //BookInventory//

        }

        internal bool Find(string login)
        {
            throw new NotImplementedException();
        }

        internal bool Find(Userss user)
        {
            throw new NotImplementedException();
        }


    }

}
