using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntryLogManagement.Models
{
    public class EntryLog
    {
        [Key]
       public int EntryLogId { get; set; }
       public DateTime CheckInTime { get; set; }
       public DateTime? CheckOutTime { get; set; }

       // Navigation properties
       [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}