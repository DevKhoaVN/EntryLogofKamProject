using System.Runtime.CompilerServices;
using EntryLogManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EntryLogManagement.Service
{
    public class AbentService
    {

        private readonly EntryContext context;

        public AbentService(EntryContext context)
        {
            this.context = context;
        }
        public void ViewAbsentReports()
        {
            var absentReports = context.AbsentReports
                .Include(ar => ar.Parent)
                .Include(ar => ar.Student)
                .ToList();

            if (absentReports.Any())
            {
                Console.WriteLine("Danh sách báo cáo vắng học:");
                foreach (var report in absentReports)
                {
                    var parent = report.Parent;
                    var student = report.Student;
                    Console.WriteLine($"Báo cáo ID: {report.AbsentReportId}");
                    Console.WriteLine($"Ngày báo cáo: {report.ReportDate}");
                    Console.WriteLine($"Lý do: {report.Reason}");
                    Console.WriteLine($"Học sinh: {student.Name} - Lớp: {student.Class}");
                    Console.WriteLine($"Phụ huynh: {parent.Name} - Số điện thoại: {parent.Phone} - Email: {parent.Email}");
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không có báo cáo vắng học nào.");
            }
        }

   // lọc 
    }
}