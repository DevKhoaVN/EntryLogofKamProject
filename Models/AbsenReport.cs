using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntryLogManagement.Models
{
    public class AbsentReport
    {
        [Key]
        public int AbsentReportId { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        public string Reason { get; set; }

        // Foreign keys

        public int ParentId { get; set; }
        public int StudentId { get; set; }
        

        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
