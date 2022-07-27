using deneeeeeee.Busines.Workers;
using deneeeeeee.Entities.Tables;
using DevExpress.XtraEditors;
using frmLisansMusteri.Musteriler;
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
    public partial class frmMusteriler : DevExpress.XtraEditors.XtraForm
    {
        YedekWorker worker = new YedekWorker();
        public frmMusteriler()
        {
            InitializeComponent();
            listele();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {

        }
        void listele()
        {
            worker.MusteriService.Load(null);
            gridControl1.DataSource = worker.MusteriService.BindingList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmMusteriIslem frm = new frmMusteriIslem(new Musteri());
            frm.ShowDialog();
            if (frm.Eklendi)
            {
                listele();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                return;
            }
            frmMusteriIslem frm = new frmMusteriIslem((Musteri)gridView1.GetFocusedRow());
            frm.ShowDialog();
            if (frm.Eklendi)
            {
                listele();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            worker.MusteriService.Load(null);
            gridControl1.DataSource = worker.MusteriService.BindingList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                return;
            }
            if (MessageBox.Show("Seçili Olan Veriyi Silmek İster misiniz ?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
                worker.Commit();
                listele();
            }
        }
    }
}