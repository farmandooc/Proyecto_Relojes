
namespace ooc_gest_Reloj.frm
{
    partial class xfrm_GestDispositivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_GestDispositivos));
            this.te_IdDispositivo = new DevExpress.XtraEditors.TextEdit();
            this.te_Clave_reloj = new DevExpress.XtraEditors.TextEdit();
            this.sbt_Aceptar = new DevExpress.XtraEditors.SimpleButton();
            this.te_IpAddrs = new DevExpress.XtraEditors.TextEdit();
            this.te_Puerto = new DevExpress.XtraEditors.TextEdit();
            this.te_Etiqueta = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ce_Eliminar = new DevExpress.XtraEditors.CheckEdit();
            this.gc_Relojes = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.te_IdDispositivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Clave_reloj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_IpAddrs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Puerto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Etiqueta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ce_Eliminar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Relojes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // te_IdDispositivo
            // 
            this.te_IdDispositivo.Location = new System.Drawing.Point(134, 26);
            this.te_IdDispositivo.Name = "te_IdDispositivo";
            this.te_IdDispositivo.Size = new System.Drawing.Size(100, 20);
            this.te_IdDispositivo.TabIndex = 0;
            this.te_IdDispositivo.ToolTip = "Id del Reloj";
            this.te_IdDispositivo.ToolTipTitle = "Id del reloj";
            // 
            // te_Clave_reloj
            // 
            this.te_Clave_reloj.Location = new System.Drawing.Point(240, 26);
            this.te_Clave_reloj.Name = "te_Clave_reloj";
            this.te_Clave_reloj.Size = new System.Drawing.Size(100, 20);
            this.te_Clave_reloj.TabIndex = 0;
            this.te_Clave_reloj.ToolTip = "Clave de coneccion con el reloj";
            this.te_Clave_reloj.ToolTipTitle = "Clave";
            // 
            // sbt_Aceptar
            // 
            this.sbt_Aceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbt_Aceptar.ImageOptions.Image")));
            this.sbt_Aceptar.Location = new System.Drawing.Point(617, 27);
            this.sbt_Aceptar.Name = "sbt_Aceptar";
            this.sbt_Aceptar.Size = new System.Drawing.Size(75, 35);
            this.sbt_Aceptar.TabIndex = 1;
            this.sbt_Aceptar.Text = "OK";
            this.sbt_Aceptar.Click += new System.EventHandler(this.sbt_Aceptar_Click);
            // 
            // te_IpAddrs
            // 
            this.te_IpAddrs.EditValue = "10.104.1.213";
            this.te_IpAddrs.Location = new System.Drawing.Point(346, 26);
            this.te_IpAddrs.Name = "te_IpAddrs";
            this.te_IpAddrs.Properties.BeepOnError = false;
            this.te_IpAddrs.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.te_IpAddrs.Properties.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False");
            this.te_IpAddrs.Properties.MaskSettings.Set("mask", "(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(" +
        "25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[" +
        "0-4][0-9])|(25[0-5]))");
            this.te_IpAddrs.Size = new System.Drawing.Size(160, 20);
            this.te_IpAddrs.TabIndex = 0;
            this.te_IpAddrs.ToolTipTitle = "Id del reloj";
            // 
            // te_Puerto
            // 
            this.te_Puerto.EditValue = "5500";
            this.te_Puerto.Location = new System.Drawing.Point(512, 26);
            this.te_Puerto.Name = "te_Puerto";
            this.te_Puerto.Size = new System.Drawing.Size(55, 20);
            this.te_Puerto.TabIndex = 0;
            this.te_Puerto.ToolTipTitle = "Id del reloj";
            // 
            // te_Etiqueta
            // 
            this.te_Etiqueta.Location = new System.Drawing.Point(5, 26);
            this.te_Etiqueta.Name = "te_Etiqueta";
            this.te_Etiqueta.Size = new System.Drawing.Size(123, 20);
            this.te_Etiqueta.TabIndex = 2;
            this.te_Etiqueta.ToolTip = "Este es el texto con el que sale en el dispositivo ";
            this.te_Etiqueta.ToolTipTitle = "Etiqueta";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ce_Eliminar);
            this.groupControl1.Controls.Add(this.te_Etiqueta);
            this.groupControl1.Controls.Add(this.sbt_Aceptar);
            this.groupControl1.Controls.Add(this.te_IdDispositivo);
            this.groupControl1.Controls.Add(this.te_Puerto);
            this.groupControl1.Controls.Add(this.te_Clave_reloj);
            this.groupControl1.Controls.Add(this.te_IpAddrs);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(704, 68);
            this.groupControl1.TabIndex = 3;
            // 
            // ce_Eliminar
            // 
            this.ce_Eliminar.Location = new System.Drawing.Point(591, 26);
            this.ce_Eliminar.Name = "ce_Eliminar";
            this.ce_Eliminar.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            this.ce_Eliminar.Properties.Appearance.Options.UseBackColor = true;
            this.ce_Eliminar.Properties.Caption = "";
            this.ce_Eliminar.Size = new System.Drawing.Size(20, 20);
            this.ce_Eliminar.TabIndex = 3;
            // 
            // gc_Relojes
            // 
            this.gc_Relojes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Relojes.Location = new System.Drawing.Point(0, 68);
            this.gc_Relojes.MainView = this.gridView1;
            this.gc_Relojes.Name = "gc_Relojes";
            this.gc_Relojes.Size = new System.Drawing.Size(704, 325);
            this.gc_Relojes.TabIndex = 4;
            this.gc_Relojes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gc_Relojes.Click += new System.EventHandler(this.gc_Relojes_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gc_Relojes;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // xfrm_GestDispositivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 393);
            this.Controls.Add(this.gc_Relojes);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ColorizeInactiveIcon = DevExpress.Utils.DefaultBoolean.False;
            this.Name = "xfrm_GestDispositivos";
            this.Opacity = 0.8D;
            this.Text = "Gest. Dispositivos";
            this.Load += new System.EventHandler(this.xfrm_GestDispositivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.te_IdDispositivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Clave_reloj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_IpAddrs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Puerto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Etiqueta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ce_Eliminar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Relojes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit te_IdDispositivo;
        private DevExpress.XtraEditors.TextEdit te_Clave_reloj;
        private DevExpress.XtraEditors.SimpleButton sbt_Aceptar;
        private DevExpress.XtraEditors.TextEdit te_IpAddrs;
        private DevExpress.XtraEditors.TextEdit te_Puerto;
        private DevExpress.XtraEditors.TextEdit te_Etiqueta;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gc_Relojes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.CheckEdit ce_Eliminar;
    }
}