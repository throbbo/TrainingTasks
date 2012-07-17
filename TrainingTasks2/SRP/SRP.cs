using System;
using System.Net.Mail;

namespace TrainingTasks2.SRP
{
    public class DbService
    {

        public void SaveDb(string email, string password)
        {
            var db = new FakeDatabase();
            var user = new User(email, password);
            db.Save(user);
        }
    }

    public class MailService
    {
        public void SendMail(string email)
        {
            var smtpClient = new FakeSmtpClient();
            var msg = new MailMessage("mysite@nowhere.com", email) { Subject = "Hello fool!" };
            smtpClient.Send(msg);
        }
    }

    public class UserService
    {
        public void Register(string email, string password)
        {
            if (!email.Contains("@"))
                throw new Exception("Email is not an email!");

            var mailService = new MailService();
            var dbService = new DbService();
            dbService.SaveDb(email, password);
            mailService.SendMail(email);
        }
    }
}
