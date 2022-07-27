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

namespace frmLisansMusteri.Musteriler
{
    public partial class frmMusteriIslem : DevExpress.XtraEditors.XtraForm
    {
        YedekWorker worker = new YedekWorker();
        private Musteri _musteriEntity;
        public bool Eklendi = false;
        public frmMusteriIslem(Musteri musteriEntity)
        {
            InitializeComponent();
            _musteriEntity = musteriEntity;
            if (_musteriEntity.Id==Guid.Empty)
            {
                _musteriEntity.Id = Guid.NewGuid();
            }
            MusteriBinding();
        }
        void MusteriBinding()
        {
            txtTicariUnvani.DataBindings.Add("Text", _musteriEntity, "TicariUnvani", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAdi.DataBindings.Add("Text", _musteriEntity, "MusteriAdi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoyadi.DataBindings.Add("Text", _musteriEntity, "MusteriSoyadi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTelefon.DataBindings.Add("Text", _musteriEntity, "Telefon", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAdresi.DataBindings.Add("Text", _musteriEntity, "Adresi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiNo.DataBindings.Add("Text", _musteriEntity, "VergiNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiDairesi.DataBindings.Add("Text", _musteriEntity, "VergiDairesi", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            worker.MusteriService.AddOrUpdate(_musteriEntity);
            worker.Commit();
            Eklendi = true;
            Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}