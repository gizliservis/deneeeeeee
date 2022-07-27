using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace deneeeeeee.Tools
{
    public class MailGonderim
    {
        public bool Gonder(string konu, string icerik, string GondMail)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("yedekleme@tumteknoloji.com.tr");
            //
            ePosta.To.Add(GondMail);
            //ePosta.To.Add("eposta2@gmail.com");
            //ePosta.To.Add("eposta3@gmail.com");
            //
            //ePosta.Attachments.Add(new Attachment(@"C:\deneme-upload.jpg"));
            ePosta.Subject = konu;
            ePosta.Body = icerik;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.yandex.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("yedekleme@tumteknoloji.com.tr", "Abc123+-*q1-");
         
           // object userState = ePosta;
            bool kontrol = true;
            try
            {
                // smtp.SendAsync(ePosta, (object)ePosta);
               smtp.Send(ePosta);

            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;
        }
    }
}
