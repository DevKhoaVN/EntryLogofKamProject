using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntryLogManagement.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; } 


        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "You cannot enter more than 100 characters")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "You cannot enter more than 100 characters")]
        public string Password { get; set; }


        // Thiết lập khóa ngoại
        [Required(ErrorMessage = "UserRoleId is required")]
        public int UserRoleId { get; set; }

        // Navigation properties
        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }


        // Initializing the Sessions collection to avoid null reference exceptions
        
        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
