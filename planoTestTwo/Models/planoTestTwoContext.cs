using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace planoTestTwo.Models
{
    public partial class planoTestTwoContext : DbContext
    {
        public planoTestTwoContext()
        {
        }

        public planoTestTwoContext(DbContextOptions<planoTestTwoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer("Server=plano-hiring.cms5owchdtsp.ap-southeast-1.rds.amazonaws.com;Database=planoTestTwo;User ID=planoTester3;Password=plano@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
