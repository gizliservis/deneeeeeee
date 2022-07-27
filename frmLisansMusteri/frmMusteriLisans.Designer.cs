
namespace frmLisansMusteri
{
    partial class frmMusteriLisans
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coMusteri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLisansAdresi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriSoyadi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTicariUnvani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLisansBaslangicYili = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLisansBitisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHatırlatmaTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLisansYili = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.colLisansNo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.comboBoxEdit1);
            this.groupControl2.Controls.Add(this.btnLisansYili);
            this.groupControl2.Controls.Add(this.btnYenile);
            this.groupControl2.Controls.Add(this.btnDuzenle);
            this.groupControl2.Controls.Add(this.btnSil);
            this.groupControl2.Controls.Add(this.btnEkle);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 434);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(986, 85);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Menü";
            // 
            // btnYenile
            // 
            this.btnYenile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYenile.Location = new System.Drawing.Point(227, 23);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(75, 60);
            this.btnYenile.TabIndex = 3;
            this.btnYenile.Text = "Yenile";
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDuzenle.Location = new System.Drawing.Point(152, 23);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(75, 60);
            this.btnDuzenle.TabIndex = 2;
            this.btnDuzenle.Text = "Düzenle";
            // 
            // btnSil
            // 
            this.btnSil.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSil.Location = new System.Drawing.Point(77, 23);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 60);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Sil";
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
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(986, 434);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.colHatırlatmaTarihi,
            this.colLisansNo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // coMusteri
            // 
            this.coMusteri.Caption = "musteri";
            this.coMusteri.FieldName = "Musteri";
            this.coMusteri.Name = "coMusteri";
            // 
            // colLisansAdresi
            // 
            this.colLisansAdresi.Caption = "Lisans Adresi";
            this.colLisansAdresi.FieldName = "LisansAdresi";
            this.colLisansAdresi.Name = "colLisansAdresi";
            this.colLisansAdresi.OptionsColumn.AllowEdit = false;
            this.colLisansAdresi.Visible = true;
            this.colLisansAdresi.VisibleIndex = 0;
            // 
            // colMusteriAdi
            // 
            this.colMusteriAdi.Caption = "MusteriAdi";
            this.colMusteriAdi.FieldName = "MusteriAdi";
            this.colMusteriAdi.Name = "colMusteriAdi";
            this.colMusteriAdi.OptionsColumn.AllowEdit = false;
            this.colMusteriAdi.Visible = true;
            this.colMusteriAdi.VisibleIndex = 1;
            // 
            // colMusteriSoyadi
            // 
            this.colMusteriSoyadi.Caption = "Soyadı";
            this.colMusteriSoyadi.FieldName = "Soyadi";
            this.colMusteriSoyadi.Name = "colMusteriSoyadi";
            this.colMusteriSoyadi.OptionsColumn.AllowEdit = false;
            this.colMusteriSoyadi.Visible = true;
            this.colMusteriSoyadi.VisibleIndex = 2;
            // 
            // colTicariUnvani
            // 
            this.colTicariUnvani.Caption = "TicariUnvan";
            this.colTicariUnvani.FieldName = "TicariUnvani";
            this.colTicariUnvani.Name = "colTicariUnvani";
            this.colTicariUnvani.OptionsColumn.AllowEdit = false;
            this.colTicariUnvani.Visible = true;
            this.colTicariUnvani.VisibleIndex = 3;
            // 
            // colLisansBaslangicYili
            // 
            this.colLisansBaslangicYili.Caption = "LisansBaşlangıçYılı";
            this.colLisansBaslangicYili.FieldName = "LisansBaslangicYili";
            this.colLisansBaslangicYili.Name = "colLisansBaslangicYili";
            this.colLisansBaslangicYili.OptionsColumn.AllowEdit = false;
            this.colLisansBaslangicYili.Visible = true;
            this.colLisansBaslangicYili.VisibleIndex = 4;
            // 
            // colMusteriId
            // 
            this.colMusteriId.Caption = "Musteri Id";
            this.colMusteriId.FieldName = "MusteriId";
            this.colMusteriId.Name = "colMusteriId";
            this.colMusteriId.OptionsColumn.AllowEdit = false;
            // 
            // colLisansBitisTarihi
            // 
            this.colLisansBitisTarihi.Caption = "Bitiş Tarihi";
            this.colLisansBitisTarihi.FieldName = "LisansBitisTarihi";
            this.colLisansBitisTarihi.Name = "colLisansBitisTarihi";
            this.colLisansBitisTarihi.OptionsColumn.AllowEdit = false;
            this.colLisansBitisTarihi.Visible = true;
            this.colLisansBitisTarihi.VisibleIndex = 5;
            // 
            // colAktif
            // 
            this.colAktif.Caption = "Aktiflik Durumu";
            this.colAktif.FieldName = "Aktif";
            this.colAktif.Name = "colAktif";
            this.colAktif.OptionsColumn.AllowEdit = false;
            this.colAktif.Visible = true;
            this.colAktif.VisibleIndex = 7;
            // 
            // colHatırlatmaTarihi
            // 
            this.colHatırlatmaTarihi.Caption = "Hatırlatma Tarihi";
            this.colHatırlatmaTarihi.FieldName = "HatırlatmaTarihi";
            this.colHatırlatmaTarihi.Name = "colHatırlatmaTarihi";
            this.colHatırlatmaTarihi.OptionsColumn.AllowEdit = false;
            this.colHatırlatmaTarihi.Visible = true;
            this.colHatırlatmaTarihi.VisibleIndex = 6;
            // 
            // btnLisansYili
            // 
            this.btnLisansYili.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLisansYili.Location = new System.Drawing.Point(302, 23);
            this.btnLisansYili.Name = "btnLisansYili";
            this.btnLisansYili.Size = new System.Drawing.Size(75, 60);
            this.btnLisansYili.TabIndex = 4;
            this.btnLisansYili.Text = "Lisan Yılı";
            this.btnLisansYili.Click += new System.EventHandler(this.btnLisansYili_Click);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "1";
            this.comboBoxEdit1.Location = new System.Drawing.Point(400, 43);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 5;
            this.comboBoxEdit1.Visible = false;
            // 
            // colLisansNo
            // 
            this.colLisansNo.Caption = "Lisans No";
            this.colLisansNo.FieldName = "LisansNo";
            this.colLisansNo.Name = "colLisansNo";
            this.colLisansNo.Visible = true;
            this.colLisansNo.VisibleIndex = 8;
            // 
            // frmMusteriLisans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 519);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "frmMusteriLisans";
            this.Text = "Lisans Ekranı";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLisansAdresi;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colTicariUnvani;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriSoyadi;
        private DevExpress.XtraGrid.Columns.GridColumn colLisansBaslangicYili;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriId;
        private DevExpress.XtraGrid.Columns.GridColumn colLisansBitisTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colHatırlatmaTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colAktif;
        private DevExpress.XtraGrid.Columns.GridColumn coMusteri;
        private DevExpress.XtraEditors.SimpleButton btnLisansYili;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colLisansNo;
    }
}