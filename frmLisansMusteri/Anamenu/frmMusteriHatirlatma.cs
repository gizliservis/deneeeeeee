using deneeeeeee.Busines.Workers;
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

namespace frmLisansMusteri.Anamenu
{
    public partial class frmMusteriHatirlatma : DevExpress.XtraEditors.XtraForm
    {
        YedekWorker worker = new YedekWorker();
         Lisans lsn = new Lisans();
        public frmMusteriHatirlatma()
        {
            InitializeComponent();
            listele();
        }
        void listele()
        {
            worker.LisansService.Load(null);
            gridControl1.DataSource = worker.LisansService.LisansListele();
            alertControl1.Show(this, "Hatırlatma", "Toplam : " + gridView1.RowCount.ToString() + " Adet \n Yenilenmeyi Bekleyen Lisans Bulunmaktadır");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var secilenlisansadresi = gridView1.GetFocusedRowCellValue(colLisansAdresi).ToString();
            var secilen = worker.LisansService.Get(c => c.LisansAdresi == secilenlisansadresi);
            secilen.Aktif = true;
            worker.LisansService.AddOrUpdate(secilen);
            worker.Commit();
        }
    }
}