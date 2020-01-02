using DH.Business.Abstracts;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DH.Business.Business
{
    public class MailBusiness : IMailBusiness
    {
        private IMailDal _mailDal;
        public MailBusiness(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }
        public void MarkAsDeleted(int mailId)
        {
            var mail = _mailDal.Get(x => x.MailId == mailId);
            mail.IsDeleted = true;
            _mailDal.Update(mail);
        }

        public Mail Get(int mailId)
        {
            var mail = _mailDal.Get(x => x.MailId == mailId);
            return mail;
        }

        public List<Mail> GetAll()
        {
            var mail = _mailDal.GetList().Where(x => x.IsDeleted == false).ToList();
            return mail;
        }

        public void Insert(Mail mail)
        {
            SendEmail(mail);
            _mailDal.Insert(mail);
        }

        public void SendEmail(Mail mail)
        {
            var body = new StringBuilder();
            body.AppendLine("Ad Soyad: " + mail.FullName);
            body.AppendLine("E-Mail Adresi: " + mail.MailAddress);
            body.AppendLine("Konu: " + mail.Subject);
            body.AppendLine("Mesaj: " + mail.Body);
            using (var smtp = new SmtpClient
            {
                Host = "mail.degirmencihukuk.com",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("info@degirmencihukuk.com", "degirmenci1508")
            })
            {
                using (var message = new MailMessage("info@degirmencihukuk.com", "info@degirmencihukuk.com") { Subject = mail.Subject, Body = body.ToString() })
                {
                    smtp.Send(message);
                }
            }
        }

        public void Update(Mail mail)
        {
            _mailDal.Update(mail);
        }
    }
}
