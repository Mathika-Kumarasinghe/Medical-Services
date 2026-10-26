
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalDeviceSafetyRecall.Models
{
    [Table("SafetyNotice")]
    public class SafetyNotice
    {
        [Key]
        [Column("notice_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoticeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string DeviceName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string DeviceType { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "date")]
        public DateTime NoticeDate { get; set; }

        [Required]
        [StringLength(100)]
        public string RecallType { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
