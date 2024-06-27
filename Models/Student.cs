using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntryLogManagement.Models
{
    public enum StudentStatusType
    {
        In,
        Out
    }

    public class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Gender {get;set;}

        public DateTime DayOfBirth {get;set;}

        public string Class {set;get;}
        public int Phone { get; set; }
        public string Address { get; set; }
        public StudentStatusType Status { get; set; } // Enum for student status

        public int ParentId { get; set; }
        
        // Navigation properties
        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }
        public virtual ICollection<EntryLog> EntryLogs { get; set; } = new List<EntryLog>();
          
         // Navigation property
         public int? AlertId {set;get;}
         [ForeignKey("AlertId")]
        public virtual Alert Alert { get; set; }
    }
}
