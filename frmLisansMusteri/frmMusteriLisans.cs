using deneeeeeee.Busines.Workers;
using deneeeeeee.Core.Functions;
using deneeeeeee.Entities.Tables;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmLisansMusteri
{
    public partial class frmMusteriLisans : DevExpress.XtraEditors.XtraForm
    {
        YedekWorker worker = new YedekWorker();
        deneeeeeee.Entities.Tables.Lisans lsn = new Lisans();
        public frmMusteriLisans()
        {
            InitializeComponent();
     
            listele();

        }
        void listele()
        {
            worker.LisansService.Load(null);
            gridControl1.DataSource = worker.LisansService.LisansListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Visible==true)
            {
                var secilenlisansadresi = gridView1.GetFocusedRowCellValue(colLisansAdresi).ToString();
                var secilen = worker.LisansService.Get(c => c.LisansAdresi == secilenlisansadresi);
                if (comboBoxEdit1.SelectedIndex == 0)
                {
                    secilen.LisansBitisTarihi = DateTime.Now.AddYears(1);
                    secilen.HatırlatmaTarihi = DateTime.Now.AddYears(1).AddDays(-30);
                    secilen.Aktif = true;
                }
                else if (comboBoxEdit1.SelectedIndex == 1)
                {
                    secilen.LisansBitisTarihi = DateTime.Now.AddYears(2);
                    secilen.HatırlatmaTarihi = DateTime.Now.AddYears(2).AddDays(-30);
                    secilen.Aktif = true;
                }
                else if (comboBoxEdit1.SelectedIndex == 2)
                {
                    secilen.LisansBitisTarihi = DateTime.Now.AddYears(3);
                    secilen.HatırlatmaTarihi = DateTime.Now.AddYears(3).AddDays(-30);
                    secilen.Aktif = true;
                }
                else if (comboBoxEdit1.SelectedIndex == 3)
                {
                    secilen.LisansBitisTarihi = DateTime.Now.AddYears(4);
                    secilen.HatırlatmaTarihi = DateTime.Now.AddYears(4).AddDays(-30);
                    secilen.Aktif = true;
                }
                else if (comboBoxEdit1.SelectedIndex == 4)
                {
                    secilen.LisansBitisTarihi = DateTime.Now.AddYears(5);
                    secilen.HatırlatmaTarihi = DateTime.Now.AddYears(5).AddDays(-30);
                    secilen.Aktif = true;
                }

                worker.LisansService.AddOrUpdate(secilen);
                worker.Commit();
                comboBoxEdit1.Visible = false;
            }
            else
            {
                MessageBox.Show("Lütfen Lisans Yılı Butonuna Basarak \n lisans Yılı seçip işlem Yapınız");
            }
           
        }

        private void btnLisansYili_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Visible==true)
            {
                comboBoxEdit1.Visible = false;
               
            }
            else
            {
                comboBoxEdit1.Visible = true;
            }
        }
    }
}