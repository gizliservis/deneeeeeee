 using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneeeeeee.Tools
{
  public  class Zipleme
    {
        string hash = "";
        public void Ziple(string dosyaYolu)
        {
           
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "Abc123+-*";
                zip.AddDirectory(dosyaYolu);
                zip.Save(dosyaYolu + ".zip");
            }
        }
        public static void SqlStarter(string serviceName)
        {

            //string myServiceName = "MSSQL$SQLEXPRESS";
            // "MSSQLSERVER";
            string myServiceName = serviceName;
            string status;

            ServiceController mySC = new ServiceController(myServiceName);

            try
            {
                status = mySC.Status.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message,"Hata");
                return;
            }


            if (mySC.Status.Equals(ServiceControllerStatus.Stopped) )
            {
                try
                {
                    mySC.Status.Equals(ServiceControllerStatus.StopPending);
                    mySC.Start();
                    mySC.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata");
                }

            }

            return;

        }
        public static void SqlStoped(string serviceName)
        {

            //string myServiceName = "MSSQL$SQLEXPRESS";
            // "MSSQLSERVER";
            string myServiceName = serviceName;
            string status;

            ServiceController mySC = new ServiceController(myServiceName);

            try
            {
                status = mySC.Status.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
                return;
            }


            if (mySC.Status.Equals(ServiceControllerStatus.Running))
            {
                try
                {
                    mySC.Status.Equals(ServiceControllerStatus.StartPending);
                    mySC.Stop();
                    mySC.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata");
                }

            }

            return;

        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public string Descrypt(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES=new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }
                    )
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.Default.GetString(results);
                }
            }
        }
        public string crypt(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }
                    )
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results,0,results.Length);
                }
            }
        }


    }
}

