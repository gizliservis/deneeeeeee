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

namespace Tumtek.Lisanslar
{
    public partial class frmMusteriSec : DevExpress.XtraEditors.XtraForm
    {
        public bool Secildi = false;
        public Musteri musteriEntity;
        YedekWorker worker = new YedekWorker();
        public frmMusteriSec()
        {
            InitializeComponent();
            listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Secildi = true;
            musteriEntity = (Musteri)gridView1.GetFocusedRow();
            Close();
        }
        void listele()
        {
            worker.MusteriService.Load(null);
            gridControl1.DataSource = worker.MusteriService.BindingList();
        }
    }
}