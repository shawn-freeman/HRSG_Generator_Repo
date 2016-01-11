using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HRSG_Library.Handlers {
    public class Email {
        public static void SendMail(string subject, string body) {
            var email = new SendGrid.SendGridMessage {
                From = new MailAddress("error@compwalk.com")
            };

            email.AddTo(ConfigurationManager.AppSettings["ERROR_EMAIL"]);
            email.Subject = subject;

            email.Html = body.Replace(System.Environment.NewLine, "<br/>");
    
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["SENDGRID_USERNAME"], ConfigurationManager.AppSettings["SENDGRID_PASSWORD"]);
            var transportWeb = new SendGrid.Web(credentials);

            var task = transportWeb.DeliverAsync(email);

            Task.WaitAll(task);
        }
    }
}