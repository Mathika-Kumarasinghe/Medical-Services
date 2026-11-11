using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Member04_SharingAndCustomerAccess.Models
{
    public class SharedFinding
    {
        [Key]
        public int SharedFindingId { get; set; }

        [Required]
        public int FindingId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int SharedByUserId { get; set; }

        public DateTime SharedDate { get; set; }
            = DateTime.UtcNow;

        [ForeignKey(nameof(FindingId))]
        public Finding? Finding { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public User? Customer { get; set; }

        [ForeignKey(nameof(SharedByUserId))]
        public User? Employee { get; set; }
    }
}