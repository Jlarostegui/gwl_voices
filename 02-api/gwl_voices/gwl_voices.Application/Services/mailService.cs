using gwl_voices.Application.Contracts.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

//namespace gwl_voices.Application.Services
//{
//    public class mailService
//    {
//        readonly IConfiguration Configuration;
//        public mailService(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public void Send(string from, string to, string subject, string html)
//        {

//            //var smtp = _configuration.GetSection("AppSettings").GetSection("smtp");
//            //var host = Encoding.ASCII.GetBytes(smtp.Value);
//            var host = Configuration["Smtp:Host"];
//            var port = Configuration["Smtp:Port"];
//            var smtpUser = Configuration["Smtp:Username"];
//            var smtpPass = Configuration["Smtp:Password"];



//            // create message
//            var email = new MimeMessage();
//            email.From.Add(MailboxAddress.Parse(from));
//            email.To.Add(MailboxAddress.Parse(to));
//            email.Subject = subject;
//            email.Body = new TextPart(TextFormat.Html) { Text = html };

//            // send email

//            using var smtp = new SmtpClient();
//            smtp.Connect(host, port, SecureSocketOptions.StartTls);
//            smtp.Authenticate(smtpUser, smtpPass);
//            smtp.Send(email);
//            smtp.Disconnect(true);
//        }


//    }
//}

namespace gwl_voices.Application.Services
{

    public class AppSettings
    {
        public string? EmailFrom { get; set; }
        public string? SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string? SmtpUser { get; set; }
        public string? SmtpPass { get; set; }
    }
    public class mailService : ImailService
    {
        private readonly AppSettings _appSettings;

        public mailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string from, string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}