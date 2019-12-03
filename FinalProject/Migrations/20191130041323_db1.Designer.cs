﻿// <auto-generated />
using System;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalProject.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20191130041323_db1")]
    partial class db1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FinalProject.Models.Authors", b =>
                {
                    b.Property<string>("Author_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Author_id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("FinalProject.Models.Books", b =>
                {
                    b.Property<string>("Book_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Book_dec")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Book_page");

                    b.Property<DateTime>("Book_pub");

                    b.Property<string>("Book_shortDec")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Book_title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pub_id");

                    b.HasKey("Book_id");

                    b.HasIndex("Pub_id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("FinalProject.Models.BooksHaveAuthors", b =>
                {
                    b.Property<string>("Author_id");

                    b.Property<string>("Book_id");

                    b.HasKey("Author_id", "Book_id");

                    b.HasIndex("Book_id");

                    b.ToTable("BooksHaveAuthors");
                });

            modelBuilder.Entity("FinalProject.Models.BooksInventory", b =>
                {
                    b.Property<string>("Book_id");

                    b.Property<string>("User_id");

                    b.HasKey("Book_id", "User_id");

                    b.HasIndex("User_id");

                    b.ToTable("BooksInventories");
                });

            modelBuilder.Entity("FinalProject.Models.BooksRequests", b =>
                {
                    b.Property<string>("Book_id");

                    b.Property<string>("User_id");

                    b.Property<string>("RequestDate");

                    b.HasKey("Book_id", "User_id");

                    b.HasIndex("User_id");

                    b.ToTable("BooksRequests");
                });

            modelBuilder.Entity("FinalProject.Models.Publishers", b =>
                {
                    b.Property<string>("Pub_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Pub_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Pub_id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("FinalProject.Models.Userss", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FinalProject.Models.Books", b =>
                {
                    b.HasOne("FinalProject.Models.Publishers", "Publishers")
                        .WithMany("Books")
                        .HasForeignKey("Pub_id");
                });

            modelBuilder.Entity("FinalProject.Models.BooksHaveAuthors", b =>
                {
                    b.HasOne("FinalProject.Models.Authors", "Authors")
                        .WithMany("BooksHaveAuthors")
                        .HasForeignKey("Author_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Books", "Book")
                        .WithMany("BooksHaveAuthors")
                        .HasForeignKey("Book_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalProject.Models.BooksInventory", b =>
                {
                    b.HasOne("FinalProject.Models.Books", "Book")
                        .WithMany("BooksInventories")
                        .HasForeignKey("Book_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Userss", "User")
                        .WithMany("BooksInventories")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalProject.Models.BooksRequests", b =>
                {
                    b.HasOne("FinalProject.Models.Books", "Book")
                        .WithMany("BooksRequests")
                        .HasForeignKey("Book_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Userss", "User")
                        .WithMany("BooksRequests")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FinalProject.Models.Userss")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FinalProject.Models.Userss")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalProject.Models.Userss")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FinalProject.Models.Userss")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}