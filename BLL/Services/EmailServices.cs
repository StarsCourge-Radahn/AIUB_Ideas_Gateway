using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmailServices
    {
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587; //465
        private const string SmtpUsername = "hereroy22@gmail.com";
        private const string SmtpPassword = "xytnbvzbmnmvqhos";

        public static bool SendForgotPasswordEmail(string toEmail, string resetCode)
        {
            try
            {
                using (var smtpClient = new SmtpClient(SmtpHost))
                {
                    smtpClient.Port = SmtpPort;
                    smtpClient.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(SmtpUsername),
                        Subject = "Password Reset",
                        Body = $"<body style=\"font-family: Arial, sans-serif; background-color: #f5f5f5; margin: 0; padding: 0;\">\r\n\r\n" +
                                $"<div style=\"max-width: 600px; margin: 0 auto; padding: 20px; background-color: #ffffff; border-radius: 10px; box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);\">\r\n" +
                                $"<div style=\"background-color: #4CAF50; color: #ffffff; padding: 10px 0; text-align: center; border-top-left-radius: 10px; border-top-right-radius: 10px;\">\r\n" +
                                $"<h1>Password Reset Confirmation</h1>\r\n" +
                                $"</div>\r\n" +
                                $"<div style=\"padding: 20px;\">\r\n" +
                                $"<p>Dear User,</p>\r\n" +
                                $"<p>You have requested to reset your password for your account. To proceed with the password reset, please use the verification code provided below:</p>\r\n" +
                                $"<p style=\"display: inline-block; font-size: 24px; font-weight: bold; background-color: #ffc107; padding: 5px 10px; border-radius: 5px;\">\r\n" +
                                $"Verification Code: <span style=\"font-size: 32px; color: #e74c3c;\">{resetCode}</span>\r\n</p>\r\n" +
                                $"<p>Please enter this code on the password reset page to verify your identity. This code will expire after a certain duration for security purposes.</p>\r\n" +
                                $"<p>If you did not request a password reset or if you have any concerns regarding your account security, please contact our support team immediately.</p>\r\n" +
                                $"</div>\r\n" +
                                $"<div style=\"margin-top: 20px; text-align: center; background-color: #4CAF50; color: #ffffff; padding: 10px 0; text-align: center; border-top-left-radius: 10px; border-top-right-radius: 10px;\">\r\n" +
                                $"<p>Best regards,<br><b>AIUB_Ideas_Gateway</b></p>\r\n" +
                                $"</div>\r\n" +
                                $"</div>\r\n\r\n" +
                                $"</body>",

                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(toEmail);

                    smtpClient.Send(mailMessage);
                }

                return true; // Email sent successfully
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return false if email sending fails
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
    }
}
