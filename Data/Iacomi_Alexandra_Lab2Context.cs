using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Iacomi_Alexandra_Lab2.Models;

namespace Iacomi_Alexandra_Lab2.Data
{
    public class Iacomi_Alexandra_Lab2Context : DbContext
    {
        public Iacomi_Alexandra_Lab2Context (DbContextOptions<Iacomi_Alexandra_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Iacomi_Alexandra_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Iacomi_Alexandra_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Iacomi_Alexandra_Lab2.Models.Author>? Authors { get; set; }

        public DbSet<Iacomi_Alexandra_Lab2.Models.Category>? Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(b => b.Book)
                .HasForeignKey<Borrowing>(b => b.BookID);
        }
        public DbSet<Iacomi_Alexandra_Lab2.Models.Member>? Member { get; set; }
        public DbSet<Iacomi_Alexandra_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
