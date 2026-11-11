
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Member04_SharingAndCustomerAccess.Data;

namespace Member04_SharingAndCustomerAccess.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            int customerId = 2; // Test Customer ID

            var sharedFindings = await _context.SharedFindings
                .Include(sf => sf.Finding)
                .Where(sf => sf.CustomerId == customerId)
                .ToListAsync();

            return View(sharedFindings);
        }

        // View details of a shared finding
        public async Task<IActionResult> FindingDetails(int id)
        {
            int customerId = 2; // Test Customer ID

            var sharedFinding = await _context.SharedFindings
                .Include(sf => sf.Finding)
                .FirstOrDefaultAsync(sf =>
                    sf.SharedFindingId == id &&
                    sf.CustomerId == customerId);

            if (sharedFinding == null)
            {
                return NotFound();
            }

            return View(sharedFinding);
        }
    }
}
