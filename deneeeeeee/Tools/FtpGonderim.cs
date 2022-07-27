using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneeeeeee.Tools
{
    public class FtpGonderim
    {
        
        public void FtpDosyaGonder(string dosyaYolu,string ftpAdresi,string kullaniciAdi,string sifre)
        {

            FileInfo FI = new FileInfo(dosyaYolu+".zip");
            // Dosyanın gönderileceği ftp yolunu belirliyoruz
            string uri = ftpAdresi +FI.Name.Replace(".zip","")+ DateTime.Now.ToString("yyMMdd HHmmss") + "-" + "TumTeknoloji";
            // Ftp işlemlerini yapacağımız sınıfımızı tanımlıyoruz
            FtpWebRequest FTP;
            // Oluşturduğumuz değişkene hedef yolumuzu gösteriyoruz
            FTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            // Ftp bağlantısı için gerekli bilgileri belirliyoruz
            FTP.Credentials = new NetworkCredential(kullaniciAdi,sifre);
            // Default olarak true geliyor false 'a çeviriyoruz. Amacımız bağlantı açıksa hataya düşmemesi
            FTP.KeepAlive = false;
            // Bu kısımda hangi işlemi yapacağımızı belirtiyoruz, dosya göndereceğimiz için UploadFile methodunu seçiyoruz
            FTP.Method = WebRequestMethods.Ftp.UploadFile;
            // Dosya tranferinin Binary türden yapılacağını belirtiyoruz
            FTP.UseBinary = true;
            // Gönderdiğimiz dosyanın boyutunu belirtiyoruz
            FTP.ContentLength = FI.Length;
            // Buffer büyüklüğünü 2KB olarak belirtiyoruz ve değişkenimizi tanımlıoyruz
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // Bu kısımda dosyayı binary'e çevirip ftp'ye gönderiyoruz
            FileStream FS = FI.OpenRead();
            try
            {
                Stream strm = FTP.GetRequestStream();
                contentLen = FS.Read(buff, 0, buffLength);
                while (contentLen != 0)//dosya bitene kadar gönderme işlemi
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = FS.Read(buff, 0, buffLength);
                }
                strm.Close();
                FS.Close();
               // MessageBox.Show("Dosya gönderildi!", "İşlem Tamam");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }
        public void FtpKlasorSilme(string ftpAdres, string kullaniciAdi, string sifre, string klasorIsmi)
        {
            FtpWebRequest FTP;
            try
            {
                FTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAdres +"/"+ klasorIsmi +"/"));
                FTP.UseBinary = true; 
                FTP.Credentials = new NetworkCredential(kullaniciAdi, sifre);
                FTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)FTP.GetResponse();
                MessageBox.Show(response.StatusDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FtpKlasorOlustur(string ftpAdres, string kullaniciAdi, string sifre, string klasorIsmi)
        {
            FtpWebRequest FTP;
            try
            {
                FTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpAdres+"/" + klasorIsmi + "/"));
                FTP.UseBinary = true;
                FTP.Credentials = new NetworkCredential(kullaniciAdi, sifre);
                FTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)FTP.GetResponse();
               MessageBox.Show(response.StatusDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
