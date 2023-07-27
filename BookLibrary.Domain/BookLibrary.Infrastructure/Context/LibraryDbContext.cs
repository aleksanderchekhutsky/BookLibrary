using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
           : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        ////    base.OnModelCreating(modelBuilder);

        ////    modelBuilder.Entity<BookAuthor>()
        ////        .HasKey(ba => new { ba.BookId, ba.AuthorId });
        ////    modelBuilder.Entity<BookAuthor>()
        ////        .HasOne(ba => ba.Book)
        ////        .WithMany(b => b.BookAuthors)
        ////        .HasForeignKey(ba => ba.BookId);
        ////    modelBuilder.Entity<BookAuthor>()
        ////.HasOne(ba => ba.Authors)
        ////.WithMany(a => a.BookAuthors)
        ////.HasForeignKey(ba => ba.AuthorId);

        //    //modelBuilder.Entity<BookAuthor>()
        //    //    .HasOne(ba => ba.Book)
        //    //    .WithMany(b => b.BookAuthors)
        //    //    .HasForeignKey(ba => ba.BookId);

        //    //modelBuilder.Entity<BookAuthor>()
        //    //    .HasOne(ba => ba.Authors)
        //    //    .WithMany(a => a.BookAuthors)
        //    //    .HasForeignKey(ba => ba.AuthorId);
        //    //modelBuilder.Entity<Book>()
        //    //    .HasMany(b => b.Authors)
        //    //    .WithMany(a => a.Books)
        //    //    .UsingEntity(j => j.ToTable("BookAuthor"));
        //    //base.OnModelCreating(modelBuilder);

        //    // modelBuilder.Entity<BookAuthor>()
        //    //.HasKey(ba => new { ba.BookId, ba.AuthorId });

        //    //    modelBuilder.Entity<BookAuthor>()
        //    //        .HasOne(ba => ba.Book)
        //    //        .WithMany(b => b.BookAuthors)
        //    //        .HasForeignKey(ba => ba.BookId);

        //    //    modelBuilder.Entity<BookAuthor>()
        //    //        .HasOne(ba => ba.Author)
        //    //        .WithMany(a => a.BookAuthors)
        //    //        .HasForeignKey(ba => ba.AuthorId);
        //    //}

        //}
    }
}
