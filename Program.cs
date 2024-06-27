using System;
using System.Text;
using EntryLogManagement.Menu;
using EntryLogManagement.Service;
using EntryLogManagement.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EntryLogManagement
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            EntryContext context = new EntryContext();
            Console.OutputEncoding = Encoding.UTF8;
          

            while (true)
            {
                switch (MainMemu.IndexMenu())
                {
                    case 1:
                        // Đăng ký tài khoản
                        Register register = new Register();
                        register.Handle(context);
                        break;

                    case 2:
                        // Đăng nhập
                        Login login = new Login(context);
                        int role = 0;
                        if ( login.HandleLogin( out role))
                        {
                             ScheduleService scheduler = new ScheduleService();
                             await scheduler.Scheduler();
                            switch (role)
                            {

                                
                                case 1:
                                    // Menu cho admin
                                    AdminService adminService = new AdminService(context);
   
                                    bool isAdminRunning = true;
                                    while (isAdminRunning)
                                    {
                                        switch (MainMemu.AdminMenu())
                                        {
                                            case 1:
                                            bool isAdminRunningChoose1 = true;
                                                while(isAdminRunningChoose1)
                                                {
                                                       switch(MainMemu.AdminStudentManagement())
                                                       {

                                                        case 1:
                                                            // lựa chọn thêm sửa xóa
                                                              bool isAdminRunningChoose1_choose1 = true;
                                                             while(isAdminRunningChoose1_choose1)
                                                             {

                                                                  switch(MainMemu.AdminStudentManagement_1())
                                                                  {
                                                                    case 1:
                                                                         // thêm học sinh
                                                                        adminService.AddStudentAndParent();
                                                                        break;

                                                                    case 2:
                                                                        // xóa học sinh
                                                                         adminService.DeleteStudentAndParent();
                                                                          break;

                                                                    case 3:
                                                                         adminService.UpdateStudentAndParent();
                                                                          break;

                                                                    case 0:

                                                                         // quay về menu trước đó
                                                                         isAdminRunningChoose1_choose1 = false; 
                                                                         break;

                                                                    default:
                                                                      Console.WriteLine("Vui lòng chọn đúng yêu cầu!");
                                                                      break;

                                                                  }
                                                             }
                                                            break;
                                                        case 2:
                                                        // chức năng xem báo cáo vắng 
                                                        bool isAdminRunningChoose1_choose2 = true;
                                                             while(isAdminRunningChoose1_choose2)
                                                             {

                                                                  switch(MainMemu.AdminStudentManagement_2())
                                                                  {
                                                                    case 1:
                                                                         // thêm học sinh
                                                                      
                                                                        break;

                                                                    case 2:
                                                                        // xóa học sinh
                                                                         adminService.DeleteStudentAndParent();
                                                                          break;

                                                                    case 3:
                                                                         adminService.UpdateStudentAndParent();
                                                                          break;

                                                                    case 0:

                                                                         // quay về menu trước đó
                                                                         isAdminRunningChoose1_choose1 = false; 
                                                                         break;

                                                                    default:
                                                                      Console.WriteLine("Vui lòng chọn đúng yêu cầu!");
                                                                      break;

                                                                  }
                                                             }
                                                             
                                                        break;
                                                        case 3:

                                                        // chức năng xem cảnh báo
                                                        break;
                                                        case 4:

                                                        // chức năng xem thôn tin học sinh
                                                        
                                                         break;

                                                         case 5:
                                                           // chuức năng chỉnh sửa lịch cảng báo
                                                         break;
                                                         case 0: 

                                                           isAdminRunningChoose1 = false;
                                                         break;

                                                         default:

                                                            Console.WriteLine("Vui lòng chọn đúng yêu cầu!");
                                                            break;
                                                         
                                                       }

                                                }
                                                
                                                break;

                                            case 2:
                                                 // logic của chức năng 2 admin
                                                Console.WriteLine("Thống kê");
                                                break;
                                            
                                            
                                            case 0:
                                                // Quay lại menu trước đó
                                                isAdminRunning = false;
                                                break;

                                            default:
                                                Console.WriteLine("Vui lòng chọn đúng yêu cầu!");
                                                break;

                                            case 3:
                                               // chuức nawgn quét entrylog
                                            break;
                                        }
                                    }
                                    break;

                                case 2:

                                    // Menu cho parent
                                    bool isParentRunning = true;
                                    ParentService parentService = new ParentService(context);

                                    while (isParentRunning)
                                    {
                                        switch (MainMemu.ParentMenu())
                                        {
                                            case 1:
                                                // Xem thông tin học sinh
                                                parentService.CheckEntryLogOfParent();
                                                break;

                                            case 2:
                                                // Xem báo cáo vắng mặt
                                              
                                                parentService.SendAbsent();
                                                break;

                                            case 0:
                                                // Quay lại menu trước đó
                                                isParentRunning = false;
                                                break;

                                            default:
                                                Console.WriteLine("Vui lòng chọn đúng yêu cầu!");
                                                break;
                                        }
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Vai trò không hợp lệ.");
                                    break;
                            }
                        }
                        else
                        {
                            // Xử lý khi đăng nhập không thành công
                            Console.WriteLine("Đăng nhập không thành công. Vui lòng thử lại.");
                        }
                        break;

                    case 0:
                        // Thoát chương trình
                        Environment.Exit(0);
                        break;

                    default:
                        // Xử lý lựa chọn không hợp lệ
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }
            }
        }
    }
}
