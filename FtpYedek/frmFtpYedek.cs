using deneeeeeee.Busines.Workers;
using deneeeeeee.Core.Functions;
using deneeeeeee.DataAccess.Contexts.Yedek;
using deneeeeeee.Tools;
using frmLisansMusteri;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using GoogleDriveExample;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Tumtek.Eklentiler;
using Tumtek.Lisans;

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
        string ayinGunu = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_AyinGunu) + " " + SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_AyinSaati);
        string klasor = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_Klasor);
        Zipleme zp = new Zipleme();
        FtpGonderim ftp = new FtpGonderim();
        bool tus1 = false;
        bool tus2 = false;
        bool tus3 = false;
        bool tus4 = false;
        bool tus5 = false;
        private string ActiveParentID;
        LisansEklenti lsn = new LisansEklenti();

        List<string> st = new List<string>();
        private DriveService service;

        string seriNo = "";

        public frmFtpYedek()
        {
            
            InitializeComponent();
            alertControl1.Show(this, "Uyarı", "Bu bir hatırlatmadır kısa süre içerisinde \n lisansınız sonlanıcaktır lütfen \n yetkilinizle Görüşün");

            if (!ConnectionStringInfo.Check())
            {
                frmVeriTabani form = new frmVeriTabani();
                form.ShowDialog();
            }
            seriNo = LisansEklenti.CPUSeriNoCek().ToString();
            YedekWorker worker = new YedekWorker();
            YedekContext context = new YedekContext();
            if (context.Lisanslar.Any(c => c.LisansAdresi == seriNo))
            {
                if (context.Lisanslar.Any(c => c.Aktif == false))
                {
                    MessageBox.Show("Lütfen Lisansınızı \n Aktifleştirmek İçin Yetkilinizle görüşün");
                    Close();

                }
                else if (context.Lisanslar.Any(c => c.Aktif == true))
                {
                    if (context.Lisanslar.Any(c=>c.LisansBitisTarihi==DateTime.Now))
                    {
                        alertControl1.Show(this, "Uyarı", "Lisans süreniz dolmuştur lütfen yetkilinizle görüşünüz");
                        var secilen = worker.LisansService.Get(c => c.LisansAdresi == LisansEklenti.CPUSeriNoCek());
                        secilen.Aktif = false;
                        worker.LisansService.AddOrUpdate(secilen);
                        worker.Commit();
                        Close();
                    }
                    if (context.Lisanslar.Any(c => c.HatırlatmaTarihi <= DateTime.Now && c.LisansBitisTarihi > DateTime.Now))
                    {
                        alertControl1.Show(this, "Uyarı", "Bu bir hatırlatmadır kısa süre içerisinde \n lisansınız sonlanıcaktır lütfen \n yetkilinizle Görüşün");
                    }
                }

            }
            else
            {

                frmLisanslamaEkrani frm = new frmLisanslamaEkrani(new deneeeeeee.Entities.Tables.Lisans());
                frm.ShowDialog();
            }



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

                    if (mssqlKullan == 1)
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
                                    ftp.FtpDosyaGonder(secilen.InnerText, ftpAdresi + "/" + klasor + "/", kullaniciAdi, hashsifre);

                                }
                                mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlandı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                //MessageBox.Show("yedekleme işlemi tamamlandı");
                                Zipleme.SqlStarter(mssqlServiceName);

                            }
                            else if (!fi.Exists)
                            {
                                mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlanamadı" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                Zipleme.SqlStarter(mssqlServiceName);
                                 MessageBox.Show("Lütefen Ayarlarınızı Yapınız");

                            }
                        }
                        catch (Exception ex)
                        {

                            Zipleme.SqlStarter(mssqlServiceName);
                            mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlanamadı" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                            // MessageBox.Show(ex.Message, "!Hata");

                        }

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
                                //MessageBox.Show("yedekleme işlemi tamamlandı");


                            }
                            else if (!fi.Exists)
                            {
                                mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlanamadı Lütfen Ayarlarınızı Yapınız" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                // MessageBox.Show("Lütefen Ayarlarınızı Yapınız");

                            }
                        }
                        catch (Exception ex)
                        {

                            mail.Gonder("Yedekleme", "FTP Yedekleme İşlemi Tamamlanamadı" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                            // MessageBox.Show(ex.Message, "!Hata");


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
        //google drive yedekleme komutu
        private async Task<bool> UploadFile(string file)
        {
            string rootId = DriveApi.GetRootID();
            ActiveParentID = rootId;
            Google.Apis.Drive.v3.Data.File uploadedFile = await DriveApi.UploadFile(file, ActiveParentID);

            long fileSize = uploadedFile.Size ?? 0;
            string[] row = { uploadedFile.Name, (fileSize / 1024f).ToString("n0") + " KB", fileSize.ToString(), uploadedFile.MimeType, uploadedFile.CreatedTime?.ToString("G"), uploadedFile.Id };
            return true;
        }
        public List<Google.Apis.Drive.v3.Data.File> GetFiles(string query = null)
        {
            List<Google.Apis.Drive.v3.Data.File> fileList = new List<Google.Apis.Drive.v3.Data.File>();
            FilesResource.ListRequest request = service.Files.List();
            request.PageSize = 1;
            request.Q = query ?? "mimeType != \"application/vnd.google-apps.folder\"";

            // hangi alanların gelmesini istiyorsak burada belirtiyoruz
            request.Fields = "nextPageToken, files(id, name, createdTime, modifiedTime, mimeType, description, size)";

            //dosyalar parça parça geliyor, her parçada nextPageToken dönüyor, nextPageToken null gelene kadar bu döngü devam eder.
            // null dönerse tüm dosyalar çekilmiştir
            do
            {
                FileList files = request.Execute();

                // her partta gelen dosyaları fileList listesine ekliyoruz
                fileList.AddRange(files.Files);
                request.PageToken = files.NextPageToken;

            } while (!string.IsNullOrEmpty(request.PageToken));

            return fileList;
        }
        public string CreateFolderAndGetID(string folderName, string parentId = null)
        {
            string query = $"mimeType = \"application/vnd.google-apps.folder\" and name = \"{folderName}\"";
            List<Google.Apis.Drive.v3.Data.File> result = GetFiles(query);
            Google.Apis.Drive.v3.Data.File file = result.FirstOrDefault();

            if (file != null)
            {
                return file.Id;
            }
            else
            {
                file = new Google.Apis.Drive.v3.Data.File
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder"
                };

                if (parentId != null)
                {
                    file.Parents = new List<string> { parentId };
                }

                var request = service.Files.Create(file);
                request.Fields = "id";
                var response = request.Execute();
                return response.Id;
            }
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
                                    //  MessageBox.Show("Google Drive ve Ftp yedekleme işlemi tamamlandı");
                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı Ayarlarınızı Kontrol Ediniz" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    Zipleme.SqlStarter(mssqlServiceName);
                                    //  MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                Zipleme.SqlStarter(mssqlServiceName);
                                //MessageBox.Show(ex.Message, "!Hata");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı Hata!" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                    Zipleme.SqlStarter(mssqlServiceName);
                    //MessageBox.Show(ex.Message);
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
                                    // MessageBox.Show("drive yedekleme işlemi tamamlandı");
                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı Lütfen Ayarlarınızı Yapın" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    // MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı Hata!" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                //  MessageBox.Show(ex.Message, "!Hata");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    mail.Gonder("Yedekleme", "FTP veya Google Drive Yedekleme İşlemi Tamamlanamadı Hata 2 !" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                    // MessageBox.Show(ex.Message);
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
                                    // MessageBox.Show("drive yedekleme işlemi tamamlandı");
                                    Zipleme.SqlStarter(mssqlServiceName);

                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "Google Drive Yedekleme İşlemi Tamamlanamadı Lütfen Ayarlarınızı Yapın" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    //  MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                    Zipleme.SqlStarter(mssqlServiceName);
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "Google Drive yedekleme İşlemi Tamamlanamadı Hata !" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                // MessageBox.Show(ex.Message, "!Hata");
                                Zipleme.SqlStarter(mssqlServiceName);
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    mail.Gonder("Yedekleme", "Google Drive yedekleme İşlemi Tamamlanamadı Hata !" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                    // MessageBox.Show(ex.Message);
                    Zipleme.SqlStarter(mssqlServiceName);
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
                                    // MessageBox.Show("drive yedekleme işlemi tamamlandı");

                                }
                                else if (!fi.Exists)
                                {
                                    mail.Gonder("Yedekleme", "Google Drive Yedekleme İşlemi Tamamlanamadı Lütfen Ayarlarınızı Yapınız" + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                    // MessageBox.Show("Lütefen Ayarlarınızı Yapınız");
                                }
                            }
                            catch (Exception ex)
                            {
                                mail.Gonder("Yedekleme", "Google Drive yedekleme İşlemi Tamamlanamadı Hata!" + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                                // MessageBox.Show(ex.Message, "!Hata");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    mail.Gonder("Yedekleme", "Google Drive yedekleme İşlemi Tamamlanamadı Hata 2 " + ex.Message + "\n" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), email);
                    //  MessageBox.Show(ex.Message);
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