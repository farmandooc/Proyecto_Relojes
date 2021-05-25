namespace ooc_gest_Reloj
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.Lst_dispositivos = new DevExpress.XtraEditors.GroupControl();
            this.relojes = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.p_Escritorio_Contenedor = new DevExpress.XtraEditors.PanelControl();
            this.sincronizarHoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Add_dispositivo = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Lst_dispositivos)).BeginInit();
            this.Lst_dispositivos.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_Escritorio_Contenedor)).BeginInit();
            this.SuspendLayout();
            // 
            // Lst_dispositivos
            // 
            this.Lst_dispositivos.Controls.Add(this.relojes);
            this.Lst_dispositivos.Controls.Add(this.btn_Add_dispositivo);
            this.Lst_dispositivos.Dock = System.Windows.Forms.DockStyle.Left;
            this.Lst_dispositivos.Location = new System.Drawing.Point(0, 0);
            this.Lst_dispositivos.Name = "Lst_dispositivos";
            this.Lst_dispositivos.Size = new System.Drawing.Size(121, 662);
            this.Lst_dispositivos.TabIndex = 0;
            this.Lst_dispositivos.Text = "Listado de Dispositivos";
            // 
            // relojes
            // 
            this.relojes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relojes.Location = new System.Drawing.Point(2, 63);
            this.relojes.Name = "relojes";
            this.relojes.Size = new System.Drawing.Size(117, 597);
            this.relojes.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sincronizarHoraToolStripMenuItem,
            this.ssToolStripMenuItem,
            this.dssToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(121, 0);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(0, 55);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 55);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // p_Escritorio_Contenedor
            // 
            this.p_Escritorio_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Escritorio_Contenedor.Location = new System.Drawing.Point(121, 55);
            this.p_Escritorio_Contenedor.Name = "p_Escritorio_Contenedor";
            this.p_Escritorio_Contenedor.Size = new System.Drawing.Size(945, 607);
            this.p_Escritorio_Contenedor.TabIndex = 3;
            // 
            // sincronizarHoraToolStripMenuItem
            // 
            this.sincronizarHoraToolStripMenuItem.AutoSize = false;
            this.sincronizarHoraToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.sincronizarHoraToolStripMenuItem.Image = global::ooc_gest_Reloj.Properties.Resources.clock_refresh;
            this.sincronizarHoraToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sincronizarHoraToolStripMenuItem.Name = "sincronizarHoraToolStripMenuItem";
            this.sincronizarHoraToolStripMenuItem.Size = new System.Drawing.Size(55, 55);
            this.sincronizarHoraToolStripMenuItem.ToolTipText = "Sincronizar Hora y fecha ";
            this.sincronizarHoraToolStripMenuItem.Click += new System.EventHandler(this.sincronizarHoraToolStripMenuItem_Click);
            // 
            // ssToolStripMenuItem
            // 
            this.ssToolStripMenuItem.Image = global::ooc_gest_Reloj.Properties.Resources.Users_cards;
            this.ssToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ssToolStripMenuItem.Name = "ssToolStripMenuItem";
            this.ssToolStripMenuItem.Size = new System.Drawing.Size(60, 51);
            this.ssToolStripMenuItem.ToolTipText = "Recoger Informacion de los usuarios";
            this.ssToolStripMenuItem.Click += new System.EventHandler(this.ssToolStripMenuItem_Click);
            // 
            // dssToolStripMenuItem
            // 
            this.dssToolStripMenuItem.Image = global::ooc_gest_Reloj.Properties.Resources._1images;
            this.dssToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dssToolStripMenuItem.Name = "dssToolStripMenuItem";
            this.dssToolStripMenuItem.Size = new System.Drawing.Size(60, 51);
            this.dssToolStripMenuItem.ToolTipText = "Marcaciones";
            // 
            // btn_Add_dispositivo
            // 
            this.btn_Add_dispositivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Add_dispositivo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add_dispositivo.ImageOptions.Image")));
            this.btn_Add_dispositivo.Location = new System.Drawing.Point(2, 23);
            this.btn_Add_dispositivo.MinimumSize = new System.Drawing.Size(0, 40);
            this.btn_Add_dispositivo.Name = "btn_Add_dispositivo";
            this.btn_Add_dispositivo.Size = new System.Drawing.Size(117, 40);
            this.btn_Add_dispositivo.TabIndex = 1;
            this.btn_Add_dispositivo.Click += new System.EventHandler(this.btn_Add_dispositivo_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 662);
            this.Controls.Add(this.p_Escritorio_Contenedor);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Lst_dispositivos);
            this.Name = "Principal";
            this.Text = "Gestion del los Relojes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lst_dispositivos)).EndInit();
            this.Lst_dispositivos.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_Escritorio_Contenedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Lst_dispositivos;
        private DevExpress.XtraEditors.SimpleButton btn_Add_dispositivo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraEditors.PanelControl p_Escritorio_Contenedor;
        private System.Windows.Forms.Panel relojes;
        private System.Windows.Forms.ToolStripMenuItem sincronizarHoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dssToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ssToolStripMenuItem;
    }
}

