
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Member04_SharingAndCustomerAccess.Data;
using Member04_SharingAndCustomerAccess.Models;
using Member04_SharingAndCustomerAccess.ViewModels;

namespace Member04_SharingAndCustomerAccess.Controllers
{
    public class SharingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SharingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display sharing form
        public async Task<IActionResult> Index()
        {
            var viewModel = new SharingViewModel();

            await LoadDropdowns(viewModel);

            return View(viewModel);
        }

        // Save shared finding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SharingViewModel model)
        {
            bool validFinding = await _context.Findings
                .AnyAsync(f => f.FindingId == model.FindingId);

            bool validCustomer = await _context.Users
                .AnyAsync(u => u.UserId == model.CustomerId
                    && u.Role == "Customer");

            bool validEmployee = await _context.Users
                .AnyAsync(u => u.UserId == model.SharedByUserId
                    && u.Role == "Employee");

            if (!validFinding || !validCustomer || !validEmployee)
            {
                ModelState.AddModelError("",
                    "Please select valid finding, customer and employee.");
            }

            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model);
                return View(model);
            }

            var sharedFinding = new SharedFinding
            {
                FindingId = model.FindingId,
                CustomerId = model.CustomerId,
                SharedByUserId = model.SharedByUserId,
                SharedDate = DateTime.UtcNow
            };

            _context.SharedFindings.Add(sharedFinding);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Finding shared successfully with the customer.";

            return RedirectToAction(nameof(Index));
        }

        // Load dropdown data
        private async Task LoadDropdowns(SharingViewModel model)
        {
            model.Findings = await _context.Findings
                .Select(f => new SelectListItem
                {
                    Value = f.FindingId.ToString(),
                    Text = f.Title
                })
                .ToListAsync();

            model.Customers = await _context.Users
                .Where(u => u.Role == "Customer")
                .Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FullName
                })
                .ToListAsync();

            model.Employees = await _context.Users
                .Where(u => u.Role == "Employee")
                .Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FullName
                })
                .ToListAsync();
        }
    }
}
jhk