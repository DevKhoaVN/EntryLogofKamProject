using System;
using System.Net;
using System.Net.Mail;

namespace EntryLogManagement.Service
{
    public class MailService
    {
        private readonly string _fromMail = "khoavanle2@gmail.com";
        private readonly string _password = "smir wrkl htvs kajx"; // Replace with secure storage method
        private readonly string _toMail = "khoavanle3@gmail.com";
        private readonly MailMessage _mail;
        private readonly SmtpClient _smtp;

        public MailService()
        {
            _mail = new MailMessage(_fromMail, _toMail)
            {
                Subject = "Thông tin về Học sinh Lê Văn Khoa",
                Body = "Con của bạn hiện không thuộc quản lý của nhà trường.",
                IsBodyHtml = true
            };

            _smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromMail, _password),
                EnableSsl = true
            };
        }

        public void SendEmail()
        {
            try
            {
                _smtp.Send(_mail);
              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gửi email thất bại. Lỗi: {ex.Message}");
                // You might want to log the exception or handle it differently based on your application's needs.
            }
            finally
            {
                // Ensure disposing of resources
                _mail.Dispose();
                _smtp.Dispose();
            }
        }
    }
}
