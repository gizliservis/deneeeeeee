using deneeeeeee.Busines.Workers;
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
using Tumtek.Eklentiler;
using Tumtek.Lisanslar;

namespace Tumtek.Lisans
{
    public partial class frmLisanslamaEkrani : DevExpress.XtraEditors.XtraForm
    {
       private deneeeeeee.Entities.Tables.Lisans _lsn=new deneeeeeee.Entities.Tables.Lisans();
        YedekWorker worker = new YedekWorker();
        //int bitisTarihi=Convert.ToInt32(DateTime.Now.ToString("yyyy"))+1;
        //int ay = Convert.ToInt32(DateTime.Now.ToString("MM"));
        //int Gün = Convert.ToInt32(DateTime.Now.ToString("dd"));
        public frmLisanslamaEkrani(deneeeeeee.Entities.Tables.Lisans lsn)
        {
            InitializeComponent();
            _lsn = lsn;
            if (_lsn.Id==Guid.Empty)
            {
                _lsn.Id = Guid.NewGuid();
            }
            dtBaslangicTarih.DateTime = DateTime.Now;
            txtLisansNo.Text= DateTime.Now.ToString("yyyy" + "MM" + "dd" + "HH" + "mm" + "ss");
            _lsn.LisansNo = txtLisansNo.Text;
            txtLisansAdresi.Text = LisansEklenti.CPUSeriNoCek();
        }

        void LisansKaydet()
        {
            _lsn.LisansAdresi = txtLisansAdresi.Text;
            _lsn.LisansBaslangicYili = dtBaslangicTarih.DateTime;
            _lsn.Aktif = false;
        }
        private void frmLisanslamaEkrani_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnLisansKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                LisansKaydet();
                worker.LisansService.AddOrUpdate(_lsn);
                worker.Commit();
                MessageBox.Show("Lisans Kaydedildi Lütfen Yetkilinizden Lisansı Aktifleştirmesini İsteyiniz");
                btnLisansKaydet.Enabled = false;
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
                return;
            }
         
            
        }

        private void textEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmMusteriSec frm = new frmMusteriSec();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
            if (frm.Secildi)
            {
                txtMusteri.Text = frm.musteriEntity.MusteriAdi;
                _lsn.MusteriId = frm.musteriEntity.Id;
            }
        }

        private void cmbYil_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}