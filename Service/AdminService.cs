using EntryLogManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EntryLogManagement.Service
{

    public interface IEditService
    {
      
    }
    public class AdminService
    {
        private readonly EntryContext context;

        public AdminService(EntryContext context)
        {
            this.context = context;
        }
        
         public void AddStudentAndParent()
        {
            Console.WriteLine("Nhập tên phụ huynh: ");
            string parentName = Console.ReadLine();

            Console.WriteLine("Nhập số điện thoại phụ huynh: ");
            int parentPhone = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập email phụ huynh: ");
            string parentEmail = Console.ReadLine();

            Console.WriteLine("Nhập email phụ huynh: ");
            string parentAddress= Console.ReadLine();

            var parent = new Parent
            {
                Name = parentName,
                Phone = parentPhone,
                Email = parentEmail,
                Address = parentAddress
            };

            context.Parents.Add(parent);
            context.SaveChanges();

            Console.WriteLine("Nhập tên học sinh: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Nhập giới tính học sinh: ");
            string studentGender = Console.ReadLine();

            Console.WriteLine("Nhập ngày sinh học sinh (yyyy-MM-dd): ");
            DateTime studentDob = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Nhập lớp học sinh: ");
            string studentClass = Console.ReadLine();

            Console.WriteLine("Nhập số điện thoại học sinh: ");
            int studentPhone = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập địa chỉ học sinh: ");
            string studentAddress = Console.ReadLine();

            var student = new Student
            {
                Name = studentName,
                Gender = studentGender,
                DayOfBirth = studentDob,
                Class = studentClass,
                Phone = studentPhone,
                Address = studentAddress,
                Status = StudentStatusType.Out, // Assuming new student starts as Out
                ParentId = parent.ParentId // Set the foreign key to parent ID
            };

            context.Students.Add(student);
            context.SaveChanges();

            Console.WriteLine("Học sinh và phụ huynh đã được thêm thành công.");
        }

         public void DeleteStudentAndParent()
        {
            Console.WriteLine("Nhập ID học sinh: ");
            int studentId = int.Parse(Console.ReadLine());

            var student = context.Students.Include(s => s.Parent).FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                var parent = student.Parent;

                context.Students.Remove(student);

                if (parent != null && !context.Students.Any(s => s.ParentId == parent.ParentId))
                {
                    context.Parents.Remove(parent);
                }

                context.SaveChanges();

                Console.WriteLine("Học sinh và phụ huynh (nếu không có con khác) đã được xóa thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy học sinh với ID đã nhập.");
            }
        }
  
     public void UpdateStudentAndParent()
{
    Console.WriteLine("Nhập ID học sinh: ");
    int studentId = int.Parse(Console.ReadLine());

    var student = context.Students.Include(s => s.Parent).FirstOrDefault(s => s.StudentId == studentId);

    if (student != null)
    {
        Console.WriteLine("Nhập tên mới của học sinh (để trống nếu không đổi): ");
        string newStudentName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newStudentName))
        {
            student.Name = newStudentName;
        }

        Console.WriteLine("Nhập giới tính mới của học sinh (để trống nếu không đổi): ");
        string newStudentGender = Console.ReadLine();
        if (!string.IsNullOrEmpty(newStudentGender))
        {
            student.Gender = newStudentGender;
        }

        Console.WriteLine("Nhập ngày sinh mới của học sinh (yyyy-MM-dd, để trống nếu không đổi): ");
        string newStudentDob = Console.ReadLine();
        if (!string.IsNullOrEmpty(newStudentDob))
        {
            student.DayOfBirth = DateTime.Parse(newStudentDob);
        }

        Console.WriteLine("Nhập lớp mới của học sinh (để trống nếu không đổi): ");
        string newStudentClass = Console.ReadLine();
        if (!string.IsNullOrEmpty(newStudentClass))
        {
            student.Class = newStudentClass;
        }

        Console.WriteLine("Nhập số điện thoại mới của học sinh (để trống nếu không đổi): ");
        string newStudentPhone = Console.ReadLine();
        if (!string.IsNullOrEmpty(newStudentPhone))
        {
            student.Phone = int.Parse(newStudentPhone);
        }

        Console.WriteLine("Nhập địa chỉ mới của học sinh (để trống nếu không đổi): ");
        string newStudentAddress = Console.ReadLine();
        if (!string.IsNullOrEmpty(newStudentAddress))
        {
            student.Address = newStudentAddress;
        }

        var parent = student.Parent;

        if (parent != null)
        {
            Console.WriteLine("Nhập tên mới của phụ huynh (để trống nếu không đổi): ");
            string newParentName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newParentName))
            {
                parent.Name = newParentName;
            }

            Console.WriteLine("Nhập số điện thoại mới của phụ huynh (để trống nếu không đổi): ");
            string newParentPhone = Console.ReadLine();
            if (!string.IsNullOrEmpty(newParentPhone))
            {
                parent.Phone = int.Parse(newParentPhone);
            }

            Console.WriteLine("Nhập email mới của phụ huynh (để trống nếu không đổi): ");
            string newParentEmail = Console.ReadLine();
            if (!string.IsNullOrEmpty(newParentEmail))
            {
                parent.Email = newParentEmail;
            }
        }

        context.SaveChanges();
        Console.WriteLine("Thông tin học sinh và phụ huynh đã được cập nhật thành công.");
    }
    else
    {
        Console.WriteLine("Không tìm thấy học sinh với ID đã nhập.");
    }
}
 }

        
 }

