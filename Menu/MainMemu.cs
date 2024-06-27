using System;

namespace EntryLogManagement.Menu
{
    public class MainMemu
    {

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

      // Menu chính
          public static int IndexMenu ()
          {
            Console.WriteLine("--------------------Chào mừng đến với Quản Lí Ra Vào--------------------");
            Console.WriteLine("1. Đăng kí");
            Console.WriteLine("2. Đăng nhập");
            

            int choose = int.Parse(Console.ReadLine());
            return choose;
          }
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

           // bảng lựa chọn  của Admin
          public static int AdminMenu()
          {
             Console.WriteLine("--------------------Chào mừng đến với bảng quan lí Admin-------------------");
            Console.WriteLine("1.Quản lí học sinh");
            Console.WriteLine("2.Quản lí ra vào ");
            Console.WriteLine("3.Thực hiện kiểm tra ra vào ");

            int choose = int.Parse(Console.ReadLine());
            return choose;
          }

          // bảng lựa chọn  của Admin : lựa chọn quản lí học sinh
          public static int AdminStudentManagement()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng quan lí học -------------------");
            Console.WriteLine("1.Thêm , sửa , xóa học sinh");
            Console.WriteLine("2.Xem báo cáo vắng học ");
            Console.WriteLine("3.Xem cảnh báo ");
            Console.WriteLine("4.Xem thông tin học sinh");
          
            Console.WriteLine("O.Quay về trang trước đó");
            
            
            int choose = int.Parse(Console.ReadLine());
            return choose;
            
          }

           // bảng lựa chọn  của Admin : lựa chọn quản lí học sinh - lựa chon 1 : thêm , xửa , xóa học sinh
          public static int AdminStudentManagement_1()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng thêm sửa xóa -------------------");
            Console.WriteLine("1.Thêm học sinh");
            Console.WriteLine("2.Xóa học sinh ");
            Console.WriteLine("3.chỉnh sửa thông tin học sinh ");
            Console.WriteLine("O.Quay về trang trước đó");
            
           
            
            int choose = int.Parse(Console.ReadLine());
            return choose;
            
          }
          
           // bảng lựa chọn  của Admin : lựa chọn quản lí học sinh - lựa chọn 2 : báo cáo vắng học
          public static int AdminStudentManagement_2()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng báo cáo vắng học  -------------------");
            Console.WriteLine("1.Lọc theo id học sinh");
            Console.WriteLine("2.Lọc theo thời gian ");
            Console.WriteLine("3.Hiển thị tất cả");
            Console.WriteLine("O.Quay về trang trước đó");
            
           
            
            int choose = int.Parse(Console.ReadLine());
            return choose;
            
          }

           // bảng lựa chọn  của Admin : lựa chọn quản lí học sinh - lựa chọn 3 : xem cảnh báo
             public static int AdminStudentManagement_3()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng xem cảnh báo -------------------");
            Console.WriteLine("1.Lọc theo id học sinh");
            Console.WriteLine("2.Lọc theo thời gian ");
            Console.WriteLine("3.Hiển thị tất cả");
            Console.WriteLine("O.Quay về trang trước đó");
            
            int choose = int.Parse(Console.ReadLine());
            return choose;
          }
                
          
            // bảng lựa chọn  của Admin : lựa chọn quản lí học sinh - lựa chọn 4 : xem thông tin học sinh
          public static int AdminStudentManagement_4()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng xem thông tin học sinh  -------------------");
            Console.WriteLine("1.Lọc theo id học sinh");
            Console.WriteLine("2.Lọc theo thời gian ");
            Console.WriteLine("3.Hiển thị tất cả");
            Console.WriteLine("O.Quay về trang trước đó");

            int choose = int.Parse(Console.ReadLine());
            return choose;
          }

             // bảng lựa chọn  của Admin : lựa chọn quản lí học sinh - lựa chọn 5 : chỉnh thời gian cảnh báo

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

           // bảng lựa chọn thứ 2 của admin : Quản lí ra vào
           public static int AdminEntryManament()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng xem quản lí ra vào  -------------------");
            Console.WriteLine("1.Xem bảng ra vào");
            Console.WriteLine("2.Học sinh đi muộn");
            Console.WriteLine("O.Quay về trang trước đó");
            
           
            int choose = int.Parse(Console.ReadLine());
            return choose;
            
          }
            
          // bảng lựa chọn thứ 2 của admin : Quản lí ra vào lựa chọn xem bảng ra vào
            public static int AdminEntryManament1()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng xem bảng ra vào  -------------------");
            Console.WriteLine("1.Lọc theo id học sinh");
            Console.WriteLine("2.Lọc theo thời gian ");
            Console.WriteLine("3.Hiển thị tất cả");
            Console.WriteLine("O.Quay về trang trước đó");      
           
            int choose = int.Parse(Console.ReadLine());
            return choose;
            
          }

           // bảng lựa chọn thứ 2 của admin : Quản lí ra vào lựa chọn xem bảng học sinh đi muộn
          public static int AdminEntryManament2()
          {
            Console.WriteLine("--------------------Chào mừng đến với bảng học sinh đi muộn -------------------");
            Console.WriteLine("1.Lọc theo id học sinh");
            Console.WriteLine("2.Lọc theo thời gian ");
            Console.WriteLine("3.Hiển thị tất cả");
            Console.WriteLine("O.Quay về trang trước đó");      
           
            int choose = int.Parse(Console.ReadLine());
            return choose;
            
          }

         

          
          

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

           // bảng lựa chọn  của Parent 

          public  static int ParentMenu()
          {
            Console.WriteLine("--------------------ParentMenu--------------------");
            Console.WriteLine("1.Xem thông tin học sinh");
            Console.WriteLine("2.Báo cáo vắng học");

            int choose = int.Parse(Console.ReadLine());
            return choose;
          }
    }
}