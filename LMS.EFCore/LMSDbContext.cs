using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LMS.EFCore.Models;

namespace LMS.EFCore
{
    public partial class LMSDbContext : DbContext
    {
        public LMSDbContext()
        {
        }

        public LMSDbContext(DbContextOptions<LMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Borrow> Borrows { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Reader> Readers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=lmsdb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.44-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .HasMaxLength(20)
                    .HasColumnName("book_id");

                entity.Property(e => e.BookCount).HasColumnName("book_count");

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .HasColumnName("book_name");

                entity.Property(e => e.BookPrice)
                    .HasPrecision(10)
                    .HasColumnName("book_price");

                entity.Property(e => e.BookSurplus).HasColumnName("book_surplus");

                entity.Property(e => e.BookWriter)
                    .HasMaxLength(50)
                    .HasColumnName("book_writer");

                entity.Property(e => e.PublishTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("publish_time");
            });

            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.HasKey(e => new { e.ReaderId, e.BookId, e.BorrowTime })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("borrow");

                entity.Property(e => e.ReaderId)
                    .HasMaxLength(20)
                    .HasColumnName("Reader_id");

                entity.Property(e => e.BookId)
                    .HasMaxLength(20)
                    .HasColumnName("Book_id");

                entity.Property(e => e.BorrowTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("borrow_time");

                entity.Property(e => e.ReturnTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("return_time");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("manager");

                entity.Property(e => e.ManagerId)
                    .HasMaxLength(15)
                    .HasColumnName("manager_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(10)
                    .HasColumnName("manager_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.Sex)
                    .HasMaxLength(4)
                    .HasColumnName("sex");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(15)
                    .HasColumnName("telephone");
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.ToTable("reader");

                entity.Property(e => e.ReaderId)
                    .HasMaxLength(20)
                    .HasColumnName("reader_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.ReaderName)
                    .HasMaxLength(15)
                    .HasColumnName("reader_name");

                entity.Property(e => e.Sex)
                    .HasMaxLength(4)
                    .HasColumnName("sex");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(15)
                    .HasColumnName("telephone");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}