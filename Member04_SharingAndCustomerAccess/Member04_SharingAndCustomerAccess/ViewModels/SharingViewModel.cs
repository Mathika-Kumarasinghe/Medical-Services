
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Member04_SharingAndCustomerAccess.ViewModels
{
    public class SharingViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int FindingId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int SharedByUserId { get; set; }

        public List<SelectListItem> Findings { get; set; }
            = new List<SelectListItem>();

        public List<SelectListItem> Customers { get; set; }
            = new List<SelectListItem>();

        public List<SelectListItem> Employees { get; set; }
            = new List<SelectListItem>();
    }
}
