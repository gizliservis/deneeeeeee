
namespace Tumtek.Lisans
{
    partial class frmLisanslamaEkrani
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
            this.txtMusteri = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLisansAdresi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtBaslangicTarih = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnLisansKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtLisansNo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLisansAdresi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangicTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangicTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLisansNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMusteri
            // 
            this.txtMusteri.Location = new System.Drawing.Point(120, 22);
            this.txtMusteri.Name = "txtMusteri";
            this.txtMusteri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtMusteri.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtMusteri.Size = new System.Drawing.Size(323, 20);
            this.txtMusteri.TabIndex = 0;
            this.txtMusteri.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.textEdit1_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(2, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Müşteri :";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtLisansAdresi
            // 
            this.txtLisansAdresi.Enabled = false;
            this.txtLisansAdresi.Location = new System.Drawing.Point(120, 47);
            this.txtLisansAdresi.Name = "txtLisansAdresi";
            this.txtLisansAdresi.Size = new System.Drawing.Size(323, 20);
            this.txtLisansAdresi.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(3, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(112, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Lisans Adresi :";
            this.labelControl2.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(0, 99);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(112, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Başlangıç Tarihi :";
            this.labelControl3.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // dtBaslangicTarih
            // 
            this.dtBaslangicTarih.EditValue = null;
            this.dtBaslangicTarih.Enabled = false;
            this.dtBaslangicTarih.Location = new System.Drawing.Point(119, 97);
            this.dtBaslangicTarih.Name = "dtBaslangicTarih";
            this.dtBaslangicTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBaslangicTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBaslangicTarih.Size = new System.Drawing.Size(324, 20);
            this.dtBaslangicTarih.TabIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.btnLisansKaydet);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 123);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(453, 74);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Menü";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton2.Location = new System.Drawing.Point(77, 23);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 49);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Aktif Et";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnLisansKaydet
            // 
            this.btnLisansKaydet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLisansKaydet.Location = new System.Drawing.Point(2, 23);
            this.btnLisansKaydet.Name = "btnLisansKaydet";
            this.btnLisansKaydet.Size = new System.Drawing.Size(75, 49);
            this.btnLisansKaydet.TabIndex = 0;
            this.btnLisansKaydet.Text = "Lisans Kaydet";
            this.btnLisansKaydet.Click += new System.EventHandler(this.btnLisansKaydet_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(1, 74);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(112, 13);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Lisans No :";
            this.labelControl7.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtLisansNo
            // 
            this.txtLisansNo.Enabled = false;
            this.txtLisansNo.Location = new System.Drawing.Point(119, 71);
            this.txtLisansNo.Name = "txtLisansNo";
            this.txtLisansNo.Size = new System.Drawing.Size(323, 20);
            this.txtLisansNo.TabIndex = 2;
            // 
            // frmLisanslamaEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 197);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dtBaslangicTarih);
            this.Controls.Add(this.txtLisansNo);
            this.Controls.Add(this.txtLisansAdresi);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtMusteri);
            this.Name = "frmLisanslamaEkrani";
            this.Text = "frmLisanslamaEkrani";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLisanslamaEkrani_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtMusteri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLisansAdresi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangicTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBaslangicTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLisansNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txtMusteri;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLisansAdresi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtBaslangicTarih;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnLisansKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtLisansNo;
    }
}