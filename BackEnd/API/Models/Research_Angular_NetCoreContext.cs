using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class Research_Angular_NetCoreContext : DbContext
    {
        public Research_Angular_NetCoreContext()
        {
        }

        public Research_Angular_NetCoreContext(DbContextOptions<Research_Angular_NetCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Resort> Resort { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.230;Initial Catalog=Research_Angular_NetCore;User ID=sa;Password=admin@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resort>(entity =>
            {
                entity.Property(e => e.ResortAddress).HasMaxLength(100);

                entity.Property(e => e.ResortImage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResortName).HasMaxLength(100);
            });
        }
    }
}
