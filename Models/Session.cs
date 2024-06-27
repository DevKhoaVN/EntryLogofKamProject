using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntryLogManagement.Models
{
    public class Session
   {
       [Key]
       public int SessionId { get; set; }
       public DateTime LoginTime { get; set; }
       public DateTime? LogoutTime { get; set; }

       // FK
        [Required]
        public int UserId { get; set; }

          // Navigation properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
   }
}