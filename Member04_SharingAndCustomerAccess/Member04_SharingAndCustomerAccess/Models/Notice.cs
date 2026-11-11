
using System;
using System.ComponentModel.DataAnnotations;

namespace Member04_SharingAndCustomerAccess.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }

        [Required]
        [StringLength(200)]
        public string DeviceName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string NoticeType { get; set; } = string.Empty;

        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
    }
}
