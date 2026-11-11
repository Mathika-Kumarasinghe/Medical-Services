
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Member04_SharingAndCustomerAccess.Data;

namespace Member04_SharingAndCustomerAccess.Controllers
{
    public class NoticeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoticeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display and filter safety and recall notices
        public async Task<IActionResult> Index(string? type)
        {
            var notices = _context.Notices.AsQueryable();

            if (!string.IsNullOrEmpty(type) && type != "All")
            {
                notices = notices.Where(n => n.NoticeType == type);
            }

            ViewBag.SelectedType = type ?? "All";

            var result = await notices
                .OrderByDescending(n => n.PublishedDate)
                .ToListAsync();

            return View(result);
        }

        // Display individual notice details
        public async Task<IActionResult> Details(int id)
        {
            var notice = await _context.Notices
                .FirstOrDefaultAsync(n => n.NoticeId == id);

            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }
    }
}
