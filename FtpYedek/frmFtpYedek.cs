using deneeeeeee.Tools;
using GoogleDriveExample;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tumtek
{
    public partial class frmFtpYedek : DevExpress.XtraEditors.XtraForm
    {
        MailGonderim mail = new MailGonderim();
        string ftpAdresi = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpAdresi);
        string kullaniciAdi = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpKullaniciAdi);
        string sifre = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpSifre);
        int mssqlKullan = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_MssqlKullan));
        string mssqlServiceName = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_MssqlServiceName);
        string email = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_Mail);
        string Json = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_Json);
        string ayinGunu = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_AyinGunu)+ " " + SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_AyinSaati);
        string klasor = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_Klasor);
        Zipleme zp = new Zipleme();
        FtpGonderim ftp = new FtpGonderim();
        bool tus1 = false;
        bool tus2 = false;
        bool tus3 = false;
        bool tus4 = false;
        bool tus5 = false;
        private string ActiveParentID;


        List<string> st = new List<string>();


        public frmFtpYedek()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            string xml = @"Saat.xml";

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xml);
            XmlNodeList bulunanNode = xmldoc.SelectNodes("/SaatYolu/Saat");
            foreach (XmlNode secilen in bulunanNode)
            {

                st.Add(secilen.InnerText);


            }


        }

        public void ftpyedek()
        {
            foreach (var item in st)
            {

                if (DateTime.Now.ToString("HH:mm:ss") == item.ToString())
                {
                    if (mssqlKullan==1)
                    {
                        Zipleme.SqlStoped(mssqlServiceName);
                        FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
                        try
                        {

                            if (fi.Exists)
                            {
                                string hashsifre = zp.Descrypt(sifre);
                                string xmlDosyasi = @"Yollar.xml";
                                XmlDocument xmlDocument = new XmlDocument();
                                xmlDocument.Load(xmlDosyasi);
                                XmlNodeList bulunanNode = xmlDocument.SelectNodes("/DosyaYolu/Yol");
                                foreach (XmlNode secilen in bulunanNode)
                                {

                                    zp.Ziple(secilen.InnerText);
                                    ftp.FtpDosyaGonder(secilen.InnerText, ftpAdresi+"/"+klasor+"/", kullaniciAdi, hashsifre);

                                }
                                mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlandı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                MessageBox.Show("yedekleme işlemi tamamlandı");

                            }
                            else if (!fi.Exists)
                            {
                                MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                            }
                        }
                        catch (Exception ex)
                        {

                            mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                            MessageBox.Show(ex.Message, "!Hata");

                        }
                        Zipleme.SqlStarter(mssqlServiceName);
                    }
                    else if (mssqlKullan == 0)
                    {
                        FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
                        try
                        {

                            if (fi.Exists)
                            {
                                string hashsifre = zp.Descrypt(sifre);
                                string xmlDosyasi = @"Yollar.xml";
                                XmlDocument xmlDocument = new XmlDocument();
                                xmlDocument.Load(xmlDosyasi);
                                XmlNodeList bulunanNode = xmlDocument.SelectNodes("/DosyaYolu/Yol");
                                foreach (XmlNode secilen in bulunanNode)
                                {

                                    zp.Ziple(secilen.InnerText);
                                    ftp.FtpDosyaGonder(secilen.InnerText, ftpAdresi + "/" + klasor + "/", kullaniciAdi, hashsifre);

                                }
                                mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlandı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                MessageBox.Show("yedekleme işlemi tamamlandı");

                            }
                            else if (!fi.Exists)
                            {
                                MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                            }
                        }
                        catch (Exception ex)
                        {

                            mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                            MessageBox.Show(ex.Message, "!Hata");

                        }
                    }
                   
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            

            if (Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_KullanilacakPlatform)) == 0)
            {

               
                    if (Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_AylikTemizle)) == 1)
                    {
                        if (DateTime.Now.ToString("dd HH:mm:ss") == ayinGunu)
                        {
                            ftp.FtpKlasorSilme(ftpAdresi, kullaniciAdi, zp.Descrypt(sifre), klasor);
                            ftp.FtpKlasorOlustur(ftpAdresi, kullaniciAdi, zp.Descrypt(sifre), klasor);
                        }
                    }
                    ftpyedek();

            }
            else if (Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_KullanilacakPlatform)) == 1)
            {
                    GoogleDriveYedek();
            }
            else if (Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_KullanilacakPlatform)) == 2)
            {
               
                    if (Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_AylikTemizle)) == 1)
                    {
                        if (DateTime.Now.ToString("dd HH:mm:ss") == ayinGunu)
                        {
                            ftp.FtpKlasorSilme(ftpAdresi, kullaniciAdi, zp.Descrypt(sifre), klasor);
                            ftp.FtpKlasorOlustur(ftpAdresi, kullaniciAdi, zp.Descrypt(sifre), klasor);
                        }
                    }
                    
                    hemgoglehemftp();

            }


        }

        private async Task<bool> UploadFile(string file)
        {
            string rootId = DriveApi.GetRootID();
            ActiveParentID = rootId;
            Google.Apis.Drive.v3.Data.File uploadedFile = await DriveApi.UploadFile(file, ActiveParentID);

            long fileSize = uploadedFile.Size ?? 0;
            string[] row = { uploadedFile.Name, (fileSize / 1024f).ToString("n0") + " KB", fileSize.ToString(), uploadedFile.MimeType, uploadedFile.CreatedTime?.ToString("G"), uploadedFile.Id };
            return true;
        }
        public async void hemgoglehemftp()
        {
            if (mssqlKullan == 1)
            {
             
                
                DriveApi = GoogleDriveAPI.GetInstance();
                try
                {

                    DriveApi.Authorize(Json);


                    foreach (var item in st)
                    {

                        if (DateTime.Now.ToString("HH:mm:ss") == item.ToString())
                        {
                            Zipleme.SqlStoped(mssqlServiceName);
                            FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
                            try
                            {

                                if (fi.Exists)
                                {
                                    string hashsifre = zp.Descrypt(sifre);
                                    string xmlDosyasi = @"Yollar.xml";
                                    XmlDocument xmlDocument = new XmlDocument();
                                    xmlDocument.Load(xmlDosyasi);
                                    XmlNodeList bulunanNode = xmlDocument.SelectNodes("/DosyaYolu/Yol");
                                    foreach (XmlNode secilen in bulunanNode)
                                    {
                                        zp.Ziple(secilen.InnerText);
                                        await UploadFile(secilen.InnerText + ".zip");
                                        ftp.FtpDosyaGonder(secilen.InnerText, ftpAdresi + "/" + klasor + "/", kullaniciAdi, hashsifre);

                                    }
                                    mail.Gonder("Yedekleme", "Google Drive ve FTP Yedekleme İşlemi Tamamlandı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    Zipleme.SqlStarter(mssqlServiceName);
                                    MessageBox.Show("drive yedekleme işlemi tamamlandı");
                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    Zipleme.SqlStarter(mssqlServiceName);
                                    MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                Zipleme.SqlStarter(mssqlServiceName);
                                MessageBox.Show(ex.Message, "!Hata");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                    Zipleme.SqlStarter(mssqlServiceName);
                    MessageBox.Show(ex.Message);
                }
               
            }
            else if (mssqlKullan == 0)
            {
                DriveApi = GoogleDriveAPI.GetInstance();
                try
                {

                    DriveApi.Authorize(Json);


                    foreach (var item in st)
                    {

                        if (DateTime.Now.ToString("HH:mm:ss") == item.ToString())
                        {
                            FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
                            try
                            {

                                if (fi.Exists)
                                {
                                    string hashsifre = zp.Descrypt(sifre);
                                    string xmlDosyasi = @"Yollar.xml";
                                    XmlDocument xmlDocument = new XmlDocument();
                                    xmlDocument.Load(xmlDosyasi);
                                    XmlNodeList bulunanNode = xmlDocument.SelectNodes("/DosyaYolu/Yol");
                                    foreach (XmlNode secilen in bulunanNode)
                                    {
                                        zp.Ziple(secilen.InnerText);
                                        await UploadFile(secilen.InnerText + ".zip");
                                        ftp.FtpDosyaGonder(secilen.InnerText, ftpAdresi + "/" + klasor + "/", kullaniciAdi, hashsifre);

                                    }
                                    mail.Gonder("Yedekleme", "Google Drive ve FTP Yedekleme İşlemi Tamamlandı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    MessageBox.Show("drive yedekleme işlemi tamamlandı");
                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                MessageBox.Show(ex.Message, "!Hata");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
        public GoogleDriveAPI DriveApi;
        public async void GoogleDriveYedek()
        {
            if (mssqlKullan == 1)
            {
                
                DriveApi = GoogleDriveAPI.GetInstance();
                try
                {

                    DriveApi.Authorize(Json);


                    foreach (var item in st)
                    {

                        if (DateTime.Now.ToString("HH:mm:ss") == item.ToString())
                        {
                            Zipleme.SqlStoped(mssqlServiceName);
                            FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
                            try
                            {

                                if (fi.Exists)
                                {
                                    string xmlDosyasi = @"Yollar.xml";
                                    XmlDocument xmlDocument = new XmlDocument();
                                    xmlDocument.Load(xmlDosyasi);
                                    XmlNodeList bulunanNode = xmlDocument.SelectNodes("/DosyaYolu/Yol");
                                    foreach (XmlNode secilen in bulunanNode)
                                    {
                                        zp.Ziple(secilen.InnerText);
                                        await UploadFile(secilen.InnerText + ".zip");

                                    }
                                    mail.Gonder("Yedekleme", "Google Drive Yedekleme İşlemi Tamamlandı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    MessageBox.Show("drive yedekleme işlemi tamamlandı");
                                    Zipleme.SqlStarter(mssqlServiceName);

                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                    Zipleme.SqlStarter(mssqlServiceName);
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "Google Drive yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                MessageBox.Show(ex.Message, "!Hata");
                                Zipleme.SqlStarter(mssqlServiceName);
                            }
                        }
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (mssqlKullan == 0)
            {
                DriveApi = GoogleDriveAPI.GetInstance();
                try
                {

                    DriveApi.Authorize(Json);


                    foreach (var item in st)
                    {

                        if (DateTime.Now.ToString("HH:mm:ss") == item.ToString())
                        {
                            FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
                            try
                            {

                                if (fi.Exists)
                                {
                                    string xmlDosyasi = @"Yollar.xml";
                                    XmlDocument xmlDocument = new XmlDocument();
                                    xmlDocument.Load(xmlDosyasi);
                                    XmlNodeList bulunanNode = xmlDocument.SelectNodes("/DosyaYolu/Yol");
                                    foreach (XmlNode secilen in bulunanNode)
                                    {
                                        zp.Ziple(secilen.InnerText);
                                        await UploadFile(secilen.InnerText + ".zip");

                                    }
                                    mail.Gonder("Yedekleme", "Google Drive Yedekleme İşlemi Tamamlandı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    MessageBox.Show("drive yedekleme işlemi tamamlandı");

                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "Google Drive Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "Google Drive yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                MessageBox.Show(ex.Message, "!Hata");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            





        }
        NotifyIcon notify_Icon = new NotifyIcon();
        private void frmFtpYedek_Load_1(object sender, EventArgs e)
        {

            notify_Icon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
        }

        private void frmFtpYedek_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                tus1 = false;
                tus2 = false;
                tus3 = false;
                tus4 = false;
                tus5 = false;
                NotifyIcon();
                NotifyBildirim("Program simge durumuna getirildi!", "Program arka planda çalışmaya devam edecek!");
            }
        }
        void NotifyIcon()
        {
            this.Hide();
            notify_Icon.Visible = true;
            notify_Icon.Text = "Gizli Servis";
            notify_Icon.BalloonTipTitle = "Gizliservis arka planda çalışıyor";
            notify_Icon.BalloonTipText = "Program sağ alt köşede konumlandı.";
            notify_Icon.BalloonTipIcon = ToolTipIcon.Info;
            notify_Icon.ShowBalloonTip(2000);
            notify_Icon.ContextMenuStrip = contextMenuStrip1;

            // notifyIcon için event ataması yaptık
            notify_Icon.MouseDoubleClick += new MouseEventHandler(notify_Icon_MouseDoubleClick);
        }
        void notify_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.Show();
            //WindowState = FormWindowState.Normal;
            //notify_Icon.Visible = false;
        }

        private void frmFtpYedek_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TamamenKapat == 1)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                tus1 = false;
                tus2 = false;
                tus3 = false;
                tus4 = false;
                tus5 = false;

                NotifyIcon();
                NotifyBildirim("Program kapatılmadı!", "Programı kapatamazsanız. Bu sebeple arka planda çalışmaya devam edecek!");
            }
        }
        int TamamenKapat = 0;
        private void oneGetirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            notify_Icon.Visible = false;
        }
        void NotifyBildirim(string baslik, string mesaj)
        {
            notify_Icon.BalloonTipText = mesaj;
            notify_Icon.BalloonTipIcon = ToolTipIcon.Info;
            notify_Icon.BalloonTipTitle = baslik;
            notify_Icon.ShowBalloonTip(3000);
        }

        private void frmFtpYedek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tus1 = true;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                tus2 = true;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                tus3 = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                if (tus1 == true && tus2 == true && tus3 == true)
                {
                    Process.Start($"{Application.StartupPath}\\deneeeeeee.exe");
                    tus1 = false;
                    tus2 = false;
                    tus3 = false;
                }
            }
            if (e.KeyCode == Keys.T)
            {
                tus4 = true;
            }
            if (e.KeyCode == Keys.U)
            {
                tus5 = true;
            }
            if (e.KeyCode == Keys.M)
            {
                if (tus4 == true && tus5 == true)
                {
                    TamamenKapat = 1;
                    Application.Exit();
                }
            }
        }
    }
}