using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using EntryLogManagement.Models;

namespace EntryLogManagement.Service
{
    public class ParentService
    {
        
        private readonly EntryContext context;
        public ParentService(EntryContext context)
        {
            this.context = context;
        }
        public void CheckEntryLogOfParent()
        {
            Console.Write("Nhập ID con của bạn : ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

             var studentOfParent = context.EntryLogs.Where(x => x.StudentId == id).ToList();
             var student = context.Students.FirstOrDefault(s => s.StudentId == id);

            if (studentOfParent != null)
            {
                  Console.WriteLine($"Thông tin học sinh: {student.Name}, Lớp: {student.Class}, Địa chỉ: {student.Address}");
                  foreach( var students in studentOfParent)
                  {
                      Console.WriteLine($"- Thời gian vào : {students.CheckInTime}, Thời gian ra : {students.CheckOutTime} ");
                  }
            }

        }

        public void SendAbsent()
        {
             Console.WriteLine("Nhập ID học sinh: ");
             int ID = int.Parse(Console.ReadLine());

             Console.WriteLine("Nhập lí do  vằng học: ");
             string reason = Console.ReadLine();

            SaveAbsent(ID , reason);
        }

        public void SaveAbsent(int id, string reason)
        {
            var student = context.Students.FirstOrDefault(x => x.StudentId == id );

            if(student != null)
            {
                var absentReport = new AbsentReport
                {
                    ReportDate = DateTime.Now,
                    Reason = reason,
                    ParentId = student.ParentId
                };
                context.AbsentReports.Add(absentReport);
                context.SaveChanges();
            }
        }
    }
}