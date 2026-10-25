
using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalDeviceSafetyRecall.Models
{
    public class SafetyNotice
    {
        [Key]
        public int NoticeId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(150)]
        public string? DeviceName { get; set; }

        [StringLength(100)]
        public string? DeviceType { get; set; }

        [StringLength(150)]
        public string? Manufacturer { get; set; }

        public DateTime? NoticeDate { get; set; }

        [StringLength(100)]
        public string? RecallType { get; set; }

        public string? Description { get; set; }
    }
}

