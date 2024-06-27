namespace EntryLogManagement.Models
{
    public class Alert
    {
        public int AlertId { get; set; }
        public int StudentId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; }
        

       // Navigation property
        public virtual ICollection<Student> Students{ get; set; }
      
    }
}