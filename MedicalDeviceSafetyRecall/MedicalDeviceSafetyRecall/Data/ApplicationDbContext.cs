
using Microsoft.EntityFrameworkCore;
using MedicalDeviceSafetyRecall.Models;

namespace MedicalDeviceSafetyRecall.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SafetyNotice> SafetyNotices { get; set; }
    }
}
