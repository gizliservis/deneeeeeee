using deneeeeeee.Core.Functions;
using DevExpress.XtraBars;
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
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
            if (!ConnectionStringInfo.Check())
            {
                frmVeriTabani form = new frmVeriTabani();
                form.ShowDialog();
            }
            frmMusteriHatirlatma frm = new frmMusteriHatirlatma();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMusteriLisans frm = new frmMusteriLisans();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMusteriler frm = new frmMusteriler();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}