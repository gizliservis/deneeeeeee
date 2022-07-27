
namespace frmLisansMusteri.Anamenu
{
    partial class frmMusteriHatirlatma
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
            this.colHatırlatmaTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLisansBitisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLisansBaslangicYili = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTicariUnvani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriSoyadi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLisansAdresi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coMusteri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colHatırlatmaTarihi
            // 
            this.colHatırlatmaTarihi.Caption = "Hatırlatma Tarihi";
            this.colHatırlatmaTarihi.FieldName = "HatırlatmaTarihi";
            this.colHatırlatmaTarihi.Name = "colHatırlatmaTarihi";
            this.colHatırlatmaTarihi.OptionsColumn.AllowEdit = false;
            this.colHatırlatmaTarihi.Visible = true;
            this.colHatırlatmaTarihi.VisibleIndex = 7;
            // 
            // colLisansBitisTarihi
            // 
            this.colLisansBitisTarihi.Caption = "Bitiş Tarihi";
            this.colLisansBitisTarihi.FieldName = "LisansBitisTarihi";
            this.colLisansBitisTarihi.Name = "colLisansBitisTarihi";
            this.colLisansBitisTarihi.OptionsColumn.AllowEdit = false;
            this.colLisansBitisTarihi.Visible = true;
            this.colLisansBitisTarihi.VisibleIndex = 6;
            // 
            // colMusteriId
            // 
            this.colMusteriId.Caption = "Musteri Id";
            this.colMusteriId.FieldName = "MusteriId";
            this.colMusteriId.Name = "colMusteriId";
            this.colMusteriId.OptionsColumn.AllowEdit = false;
            // 
            // colLisansBaslangicYili
            // 
            this.colLisansBaslangicYili.Caption = "LisansBaşlangıçYılı";
            this.colLisansBaslangicYili.FieldName = "LisansBaslangicYili";
            this.colLisansBaslangicYili.Name = "colLisansBaslangicYili";
            this.colLisansBaslangicYili.OptionsColumn.AllowEdit = false;
            this.colLisansBaslangicYili.Visible = true;
            this.colLisansBaslangicYili.VisibleIndex = 5;
            // 
            // colTicariUnvani
            // 
            this.colTicariUnvani.Caption = "Ticari Unvanı";
            this.colTicariUnvani.FieldName = "TicariUnvani";
            this.colTicariUnvani.Name = "colTicariUnvani";
            this.colTicariUnvani.OptionsColumn.AllowEdit = false;
            this.colTicariUnvani.Visible = true;
            this.colTicariUnvani.VisibleIndex = 4;
            // 
            // colMusteriSoyadi
            // 
            this.colMusteriSoyadi.Caption = "Soyadı";
            this.colMusteriSoyadi.FieldName = "Soyadi";
            this.colMusteriSoyadi.Name = "colMusteriSoyadi";
            this.colMusteriSoyadi.OptionsColumn.AllowEdit = false;
            this.colMusteriSoyadi.Visible = true;
            this.colMusteriSoyadi.VisibleIndex = 3;
            // 
            // colMusteriAdi
            // 
            this.colMusteriAdi.Caption = "Musteri Adı";
            this.colMusteriAdi.FieldName = "MusteriAdi";
            this.colMusteriAdi.Name = "colMusteriAdi";
            this.colMusteriAdi.OptionsColumn.AllowEdit = false;
            this.colMusteriAdi.Visible = true;
            this.colMusteriAdi.VisibleIndex = 2;
            // 
            // colAktif
            // 
            this.colAktif.Caption = "Aktiflik Durumu";
            this.colAktif.FieldName = "Aktif";
            this.colAktif.Name = "colAktif";
            this.colAktif.OptionsColumn.AllowEdit = false;
            this.colAktif.Visible = true;
            this.colAktif.VisibleIndex = 8;
            // 
            // colLisansAdresi
            // 
            this.colLisansAdresi.Caption = "Lisans Adresi";
            this.colLisansAdresi.FieldName = "LisansAdresi";
            this.colLisansAdresi.Name = "colLisansAdresi";
            this.colLisansAdresi.OptionsColumn.AllowEdit = false;
            this.colLisansAdresi.Visible = true;
            this.colLisansAdresi.VisibleIndex = 1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coMusteri,
            this.colLisansAdresi,
            this.colMusteriAdi,
            this.colMusteriSoyadi,
            this.colTicariUnvani,
            this.colLisansBaslangicYili,
            this.colMusteriId,
            this.colLisansBitisTarihi,
            this.colAktif,
            this.colHatırlatmaTarihi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // coMusteri
            // 
            this.coMusteri.Caption = "musteri";
            this.coMusteri.FieldName = "Musteri";
            this.coMusteri.Name = "coMusteri";
            this.coMusteri.Visible = true;
            this.coMusteri.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(981, 325);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // btnEkle
            // 
            this.btnEkle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEkle.Location = new System.Drawing.Point(2, 23);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 60);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Aktif Et";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnEkle);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 325);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(981, 85);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Menü";
            // 
            // frmMusteriHatirlatma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 410);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "frmMusteriHatirlatma";
            this.Text = "Lisans Hatırlatma";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colHatırlatmaTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colLisansBitisTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriId;
        private DevExpress.XtraGrid.Columns.GridColumn colLisansBaslangicYili;
        private DevExpress.XtraGrid.Columns.GridColumn colTicariUnvani;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriSoyadi;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colAktif;
        private DevExpress.XtraGrid.Columns.GridColumn colLisansAdresi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn coMusteri;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
    }
}