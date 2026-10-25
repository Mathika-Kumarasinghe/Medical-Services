using Microsoft.EntityFrameworkCore;

namespace MedicalDeviceSafetyRecall.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}