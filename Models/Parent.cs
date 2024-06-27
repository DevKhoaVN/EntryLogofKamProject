using System.ComponentModel.DataAnnotations.Schema;

namespace EntryLogManagement.Models
{
    public class Parent
    {
    public int ParentId { get; set; }

    public int Phone { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
   

    // Navigation property
     public virtual ICollection<AbsentReport> AbsentReports {get;set;} = new List<AbsentReport>();
     
    // Navigation property
    public  virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}