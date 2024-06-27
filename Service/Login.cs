using EntryLogManagement.Models;
using System;
using System.Linq;

namespace EntryLogManagement.Service
{
    public class Login
    {
        private readonly EntryContext _context;

        public Login(EntryContext context)
        {
            _context = context;
        }

        public bool HandleLogin(out int userRole)
        {
            Console.Write("Nhập tài khoản : ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Nhập mật khẩu : ");
            string password = Console.ReadLine();
            Console.WriteLine();

            var user = _context.Users.FirstOrDefault(x => x.Username == userName);
           

            if (user != null && user.Password == password)
            {
                 userRole = user.UserRoleId;
                Console.WriteLine("Bạn đã đăng nhập thành công !");
              
                return true;
            }
            else
            {
                Console.WriteLine("Hãy kiểm tra Tài khoản và Mật khẩu của bạn hoặc đăng kí tài khoản mới");
                userRole = 0;
                return false;
            }
        }
    }
}
