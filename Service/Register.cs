using EntryLogManagement.Models;
using System;
using System.Linq;

namespace EntryLogManagement.Service
{
    public class Register
    {

        public void Handle(EntryContext context)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;  // Thiết lập mã hóa UTF-8 cho console

            Console.Write("Nhập tên tài khoản của bạn: ");
            string userName = Console.ReadLine();

            // Kiểm tra xem username đã tồn tại chưa
            if (context.Users.Any(u => u.Username == userName))
            {
                Console.WriteLine("Tên tài khoản đã tồn tại. Vui lòng chọn tên khác.");
                return;
            }

            Console.Write("Nhập mật khẩu của bạn: ");
            string password = Console.ReadLine();

            Console.Write("Nhập ID con của bạn: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                // Kiểm tra xem ID học sinh có tồn tại trong cơ sở dữ liệu hay không
                var student = context.Students.FirstOrDefault(x => x.StudentId == studentId);

                if (student != null)
                {
                    // Tạo người dùng mới
                    var newUser = new User
                    {
                        Username = userName,
                        Password = password,
                        UserRoleId = 2, // Đặt một UserRoleId mặc định, thay đổi nếu cần
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    Console.WriteLine("Đăng ký thành công!");
                }
                else
                {
                    Console.WriteLine("ID học sinh không tồn tại.");
                }
            }
            else
            {
                Console.WriteLine("ID không hợp lệ. Vui lòng nhập một số nguyên.");
            }
        }
    }
}
