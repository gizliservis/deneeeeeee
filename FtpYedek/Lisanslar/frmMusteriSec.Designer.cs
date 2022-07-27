
namespace Tumtek.Lisanslar
{
    partial class frmMusteriSec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnLisansKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.musteriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTicariUnvani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriSoyadi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVergiNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVergiDairesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlacak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKaydeden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKaydedilmeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDegistiren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDegistirmeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.btnLisansKaydet);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 348);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(881, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Menü";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.Location = new System.Drawing.Point(729, 23);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 75);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Seç";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnLisansKaydet
            // 
            this.btnLisansKaydet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLisansKaydet.Location = new System.Drawing.Point(804, 23);
            this.btnLisansKaydet.Name = "btnLisansKaydet";
            this.btnLisansKaydet.Size = new System.Drawing.Size(75, 75);
            this.btnLisansKaydet.TabIndex = 2;
            this.btnLisansKaydet.Text = "Kapat";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.musteriBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(881, 348);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // musteriBindingSource
            // 
            this.musteriBindingSource.DataSource = typeof(deneeeeeee.Entities.Tables.Musteri);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTicariUnvani,
            this.colMusteriAdi,
            this.colMusteriSoyadi,
            this.colTelefon,
            this.colAdresi,
            this.colVergiNo,
            this.colVergiDairesi,
            this.colBorc,
            this.colAlacak,
            this.colId,
            this.colKaydeden,
            this.colKaydedilmeTarihi,
            this.colDegistiren,
            this.colDegistirmeTarihi,
            this.colAciklama});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(677, 321, 252, 266);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colTicariUnvani
            // 
            this.colTicariUnvani.FieldName = "TicariUnvani";
            this.colTicariUnvani.Name = "colTicariUnvani";
            this.colTicariUnvani.OptionsColumn.AllowEdit = false;
            this.colTicariUnvani.Visible = true;
            this.colTicariUnvani.VisibleIndex = 0;
            // 
            // colMusteriAdi
            // 
            this.colMusteriAdi.FieldName = "MusteriAdi";
            this.colMusteriAdi.Name = "colMusteriAdi";
            this.colMusteriAdi.OptionsColumn.AllowEdit = false;
            this.colMusteriAdi.Visible = true;
            this.colMusteriAdi.VisibleIndex = 1;
            // 
            // colMusteriSoyadi
            // 
            this.colMusteriSoyadi.FieldName = "MusteriSoyadi";
            this.colMusteriSoyadi.Name = "colMusteriSoyadi";
            this.colMusteriSoyadi.OptionsColumn.AllowEdit = false;
            this.colMusteriSoyadi.Visible = true;
            this.colMusteriSoyadi.VisibleIndex = 2;
            // 
            // colTelefon
            // 
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.OptionsColumn.AllowEdit = false;
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 3;
            // 
            // colAdresi
            // 
            this.colAdresi.FieldName = "Adresi";
            this.colAdresi.Name = "colAdresi";
            this.colAdresi.OptionsColumn.AllowEdit = false;
            this.colAdresi.Visible = true;
            this.colAdresi.VisibleIndex = 4;
            // 
            // colVergiNo
            // 
            this.colVergiNo.FieldName = "VergiNo";
            this.colVergiNo.Name = "colVergiNo";
            this.colVergiNo.OptionsColumn.AllowEdit = false;
            this.colVergiNo.Visible = true;
            this.colVergiNo.VisibleIndex = 5;
            // 
            // colVergiDairesi
            // 
            this.colVergiDairesi.FieldName = "VergiDairesi";
            this.colVergiDairesi.Name = "colVergiDairesi";
            this.colVergiDairesi.OptionsColumn.AllowEdit = false;
            this.colVergiDairesi.Visible = true;
            this.colVergiDairesi.VisibleIndex = 6;
            // 
            // colBorc
            // 
            this.colBorc.FieldName = "Borc";
            this.colBorc.Name = "colBorc";
            this.colBorc.OptionsColumn.AllowEdit = false;
            this.colBorc.Visible = true;
            this.colBorc.VisibleIndex = 7;
            // 
            // colAlacak
            // 
            this.colAlacak.FieldName = "Alacak";
            this.colAlacak.Name = "colAlacak";
            this.colAlacak.OptionsColumn.AllowEdit = false;
            this.colAlacak.Visible = true;
            this.colAlacak.VisibleIndex = 8;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            // 
            // colKaydeden
            // 
            this.colKaydeden.FieldName = "Kaydeden";
            this.colKaydeden.Name = "colKaydeden";
            this.colKaydeden.OptionsColumn.AllowEdit = false;
            // 
            // colKaydedilmeTarihi
            // 
            this.colKaydedilmeTarihi.FieldName = "KaydedilmeTarihi";
            this.colKaydedilmeTarihi.Name = "colKaydedilmeTarihi";
            this.colKaydedilmeTarihi.OptionsColumn.AllowEdit = false;
            // 
            // colDegistiren
            // 
            this.colDegistiren.FieldName = "Degistiren";
            this.colDegistiren.Name = "colDegistiren";
            this.colDegistiren.OptionsColumn.AllowEdit = false;
            // 
            // colDegistirmeTarihi
            // 
            this.colDegistirmeTarihi.FieldName = "DegistirmeTarihi";
            this.colDegistirmeTarihi.Name = "colDegistirmeTarihi";
            this.colDegistirmeTarihi.OptionsColumn.AllowEdit = false;
            // 
            // colAciklama
            // 
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 9;
            // 
            // frmMusteriSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 448);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMusteriSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Musteri Seçim Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musteriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnLisansKaydet;
        private System.Windows.Forms.BindingSource musteriBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTicariUnvani;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriSoyadi;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresi;
        private DevExpress.XtraGrid.Columns.GridColumn colVergiNo;
        private DevExpress.XtraGrid.Columns.GridColumn colVergiDairesi;
        private DevExpress.XtraGrid.Columns.GridColumn colBorc;
        private DevExpress.XtraGrid.Columns.GridColumn colAlacak;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colKaydeden;
        private DevExpress.XtraGrid.Columns.GridColumn colKaydedilmeTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colDegistiren;
        private DevExpress.XtraGrid.Columns.GridColumn colDegistirmeTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    }
}