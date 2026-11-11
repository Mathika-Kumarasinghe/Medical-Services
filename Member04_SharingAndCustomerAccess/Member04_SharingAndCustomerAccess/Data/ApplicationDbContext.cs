
using Microsoft.EntityFrameworkCore;
using Member04_SharingAndCustomerAccess.Models;

namespace Member04_SharingAndCustomerAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Finding> Findings { get; set; }

        public DbSet<SharedFinding> SharedFindings { get; set; }

        public DbSet<Notice> Notices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SharedFinding>()
                .HasOne(s => s.Finding)
                .WithMany()
                .HasForeignKey(s => s.FindingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SharedFinding>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SharedFinding>()
                .HasOne(s => s.Employee)
                .WithMany()
                .HasForeignKey(s => s.SharedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
