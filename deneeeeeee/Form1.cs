using deneeeeeee.Tools;
using Ionic.Zip;
using Quartz.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;

namespace deneeeeeee
{
    public partial class Form1 : Form
    {
        // XmlTextWriter veri;
        Zipleme zp = new Zipleme();
        public Form1()
        {
            InitializeComponent();

            dateEdit1.DateTime = DateTime.Now;
            FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
            FileInfo saat = new FileInfo(Application.StartupPath + "\\" + "Saat.xml");
            if (!fi.Exists)
            {
                XmlDocument xdoc = new XmlDocument();
                XmlNode root = xdoc.CreateElement("DosyaYolu");
                xdoc.AppendChild(root);
                using (SaveFileDialog sf = new SaveFileDialog())
                {
                    sf.Filter = "XML Dosyası |* .xml";
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        xdoc.Save("Yollar.xml");
                        MessageBox.Show("dosya oluştu");
                    }
                }
            }
            if (!saat.Exists)
            {
                XmlDocument xdoc = new XmlDocument();
                XmlNode root = xdoc.CreateElement("SaatYolu");
                xdoc.AppendChild(root);
                using (SaveFileDialog sf = new SaveFileDialog())
                {
                    sf.Filter = "XML Dosyası |* .xml";
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        xdoc.Save("Saat.xml");
                        MessageBox.Show("dosya oluştu");
                    }
                }
            }
            FtpListele();


        }
        void FtpListele()
        {
            FileInfo fi = new FileInfo(Application.StartupPath + "\\" + "Yollar.xml");
            if (fi.Exists)
            {
                string xmlDosyasi = @"Yollar.xml";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlDosyasi);
                XmlNodeList bulunanNode = xmlDocument.SelectNodes("/DosyaYolu/Yol");
                foreach (XmlNode secilen in bulunanNode)
                {
                    listBoxControl1.Items.Add(secilen.InnerText);


                }

                txtFtAdresi.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpAdresi);

                txtKullaniciAdi.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpKullaniciAdi);
                txtSifre.Text = zp.Descrypt(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpSifre));
                cmbKullPlat.SelectedIndex= Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_KullanilacakPlatform));
            }
            FileInfo saat = new FileInfo(Application.StartupPath + "\\" + "Saat.xml");
            if (fi.Exists)
            {
                string xmlDosyasi = @"Saat.xml";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlDosyasi);
                XmlNodeList bulunanNode = xmlDocument.SelectNodes("/SaatYolu/Saat");
                foreach (XmlNode secilen in bulunanNode)
                {
                    listBoxControl2.Items.Add(secilen.InnerText);


                }

                txtFtAdresi.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpAdresi);
                cmbOtomatik.SelectedIndex = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_Checked));
                cmbKullPlat.SelectedIndex = Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_KullanilacakPlatform));
                txtKullaniciAdi.Text = SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpKullaniciAdi);
                txtSifre.Text = zp.Descrypt(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_FtpSifre));
            }


        }
        void FtpKaydet()
        {
            if (txtFtAdresi.Text != "" && txtKullaniciAdi.Text != "" && txtSifre.Text != "")
            {
                try
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(Application.StartupPath + "\\Yollar.xml");
                    XmlElement dy = (XmlElement)xdoc.SelectSingleNode("DosyaYolu");
                    foreach (var item in lstEklenecekDosyalar.Items)
                    {
                        XmlElement yol = xdoc.CreateElement("Yol");
                        yol.InnerText = item.ToString();
                        dy.AppendChild(yol);

                    }

                    xdoc.Save(Application.StartupPath + "\\Yollar.xml");






                    SettingsTool.AyarDegistir(SettingsTool.Ayarlar.FTP_Checked, cmbOtomatik.SelectedIndex.ToString());
                    SettingsTool.AyarDegistir(SettingsTool.Ayarlar.FTP_KullanilacakPlatform, cmbKullPlat.SelectedIndex.ToString());
                    SettingsTool.AyarDegistir(SettingsTool.Ayarlar.FTP_FtpAdresi, txtFtAdresi.Text);
                    SettingsTool.AyarDegistir(SettingsTool.Ayarlar.FTP_FtpKullaniciAdi, txtKullaniciAdi.Text);
                    SettingsTool.AyarDegistir(SettingsTool.Ayarlar.FTP_FtpSifre, zp.crypt(txtSifre.Text));
                    SettingsTool.save();

                    MessageBox.Show("İşlem Tmamlandı");
                    listBoxControl1.Items.Clear();
                    lstEklenecekDosyalar.Items.Clear();
                    FtpListele();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "!Hata");
                }


            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz");
            }

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            FtpKaydet();
        }

        private void txtDosyaYolu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog form = new FolderBrowserDialog();

            if (form.ShowDialog() == DialogResult.OK)
            {
                lstEklenecekDosyalar.Items.Add(form.SelectedPath);

            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(Application.StartupPath + "\\Saat.xml");
            XmlElement dy = (XmlElement)xdoc.SelectSingleNode("SaatYolu");
            foreach (var item in listBoxControl3.Items)
            {
                XmlElement yol = xdoc.CreateElement("Saat");
                yol.InnerText = item.ToString();
                dy.AppendChild(yol);

            }

            xdoc.Save(Application.StartupPath + "\\Saat.xml");

            listBoxControl1.Items.Clear();
            lstEklenecekDosyalar.Items.Clear();
            listBoxControl2.Items.Clear();
            listBoxControl3.Items.Clear();
            FtpListele();
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dateEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                listBoxControl3.Items.Add(dateEdit1.DateTime.ToString("HH:mm:ss"));
            }
        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_Checked)) == 0)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("Tumtek.exe", "\"" + Application.StartupPath + "\"Tumtek.exe");
            }
            else if (Convert.ToInt32(SettingsTool.AyarOku(SettingsTool.Ayarlar.FTP_Checked)) == 1)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue("Tumtek.exe");
            }
        }

        //private void chkOtomatik_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkOtomatik.Checked)
        //    {
        //        SettingsTool.AyarDegistir(SettingsTool.Ayarlar.FTP_Checked, chkOtomatik.ToString()) ;
        //        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
        //        key.SetValue("Tumtek.exe", "\"" + Application.ExecutablePath + "\"");
        //    }
        //    else
        //    {
        //        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
        //        key.DeleteValue("Tumtek.exe");
        //    }
        //}
    }
}
