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
            ePosta.From = new MailAddress("icb_1998@hotmail.com");
            //
            ePosta.To.Add(GondMail);
            //ePosta.To.Add("eposta2@gmail.com");
            //ePosta.To.Add("eposta3@gmail.com");
            //
            //ePosta.Attachments.Add(new Attachment(@"C:\deneme-upload.jpg"));
            ePosta.Subject = konu;
            ePosta.Body = icerik;
            SmtpClient smtp = new SmtpClient("outlook.com");
            smtp.Credentials = new System.Net.NetworkCredential("icb_1998@hotmail.com", "Cib_17421");
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
           // object userState = ePosta;
            bool kontrol = true;
            try
            {
                 smtp.SendAsync(ePosta, (object)ePosta);
               // smtp.Send(ePosta);

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
