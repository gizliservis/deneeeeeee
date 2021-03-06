using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneeeeeee.Tools
{
    public static class SettingsTool
    {
        static FileIniDataParser parser = new FileIniDataParser();
        static IniData data;
        static string dosyaAdi = "Settings.ini";

        static SettingsTool()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\" + dosyaAdi) == true)
            {
                data = parser.ReadFile(dosyaAdi);
            }
            else
            {
                using (System.IO.File.Create(Application.StartupPath + "\\" + dosyaAdi))
                {

                };
                data = parser.ReadFile(dosyaAdi);
            }
        }
        public enum Ayarlar
        {
            FTP_KaynakDosyaYolu,
            FTP_KaynakDosyaYolu2,
            FTP_KaynakDosyaYolu3,
            FTP_FtpAdresi,
            FTP_FtpKullaniciAdi,
            FTP_FtpSifre,
            FTP_KullanilacakPlatform,
            FTP_MssqlKullan,
            FTP_MssqlServiceName,
            FTP_Json,
            FTP_Mail,
            FTP_AylikTemizle,
            FTP_AyinGunu,
            FTP_AyinSaati,
            FTP_Klasor
                
            

        }
        public static void AyarDegistir(Ayarlar ayar, string value)
        {
            string[] gelenAyar = ayar.ToString().Split(Convert.ToChar("_"));
            if (data != null)
            {
                if (data.Sections.Count(c => c.SectionName == gelenAyar[0]) == 0)
                {
                    data.Sections.AddSection(gelenAyar[0]);
                    data[gelenAyar[0]].AddKey(gelenAyar[1]);

                }
                else
                {
                    data[gelenAyar[0]].AddKey(gelenAyar[1]);
                }
                data[gelenAyar[0]][gelenAyar[1]] = value;
            }
        }
    
        public static string AyarOku(Ayarlar ayar)
        {
            string[] gelenAyar = ayar.ToString().Split(Convert.ToChar("_"));
            return data[gelenAyar[0]][gelenAyar[1]];
        }
        public static void save()
        {
            parser.WriteFile(dosyaAdi, data);
        }
    }
}
