using System.ComponentModel.DataAnnotations;

namespace EntryLogManagement.Models
{

    public enum UserRoleType
    {
          admin,
          parent
    }


    public class UserRole
    {
        [Key]
       public int UserRoleId { get; set; }
       public UserRoleType RoleName { get; set; }

       // Navigation properties
       public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}