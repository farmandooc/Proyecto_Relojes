
namespace ooc_gest_Reloj.frm
{
    partial class xfrm_GetTrabajadores
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.Relojes_Operaciones = new DevExpress.XtraEditors.GroupControl();
            this.pc_operaciones = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sptn_Sinc_Relojes = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_Cargar_All_Trabajadores = new DevExpress.XtraEditors.SimpleButton();
            this.pc_Relojes = new DevExpress.XtraEditors.PanelControl();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.lst_Bien = new System.Windows.Forms.ListView();
            this.gc_Trabajadoreso = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lb_Barra_estado = new DevExpress.XtraEditors.LabelControl();
            this.lst_fallos = new System.Windows.Forms.ListView();
            this.pb_Trabajadores = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Relojes_Operaciones)).BeginInit();
            this.Relojes_Operaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_operaciones)).BeginInit();
            this.pc_operaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_Relojes)).BeginInit();
            this.pc_Relojes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Trabajadoreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.Relojes_Operaciones);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gc_Trabajadoreso);
            this.splitContainerControl1.Panel2.Controls.Add(this.lb_Barra_estado);
            this.splitContainerControl1.Panel2.Controls.Add(this.lst_fallos);
            this.splitContainerControl1.Panel2.Controls.Add(this.pb_Trabajadores);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1322, 701);
            this.splitContainerControl1.SplitterPosition = 200;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // Relojes_Operaciones
            // 
            this.Relojes_Operaciones.Controls.Add(this.pc_operaciones);
            this.Relojes_Operaciones.Controls.Add(this.pc_Relojes);
            this.Relojes_Operaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Relojes_Operaciones.Location = new System.Drawing.Point(0, 0);
            this.Relojes_Operaciones.Name = "Relojes_Operaciones";
            this.Relojes_Operaciones.Size = new System.Drawing.Size(200, 701);
            this.Relojes_Operaciones.TabIndex = 0;
            this.Relojes_Operaciones.Text = "Relojes : Operaciones";
            // 
            // pc_operaciones
            // 
            this.pc_operaciones.Controls.Add(this.simpleButton1);
            this.pc_operaciones.Controls.Add(this.sptn_Sinc_Relojes);
            this.pc_operaciones.Controls.Add(this.sbtn_Cargar_All_Trabajadores);
            this.pc_operaciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pc_operaciones.Location = new System.Drawing.Point(135, 23);
            this.pc_operaciones.Name = "pc_operaciones";
            this.pc_operaciones.Size = new System.Drawing.Size(63, 676);
            this.pc_operaciones.TabIndex = 1;
            this.pc_operaciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pc_operaciones_Paint);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton1.ImageOptions.Image = global::ooc_gest_Reloj.Properties.Resources.Sincronizar_relojes_desde_otro_48x55;
            this.simpleButton1.Location = new System.Drawing.Point(2, 106);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(59, 72);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.ToolTip = "Obtener los trabajadores de los dispositivos ";
            // 
            // sptn_Sinc_Relojes
            // 
            this.sptn_Sinc_Relojes.Dock = System.Windows.Forms.DockStyle.Top;
            this.sptn_Sinc_Relojes.ImageOptions.Image = global::ooc_gest_Reloj.Properties.Resources.Sincronizar_relojes_48x41;
            this.sptn_Sinc_Relojes.Location = new System.Drawing.Point(2, 54);
            this.sptn_Sinc_Relojes.Name = "sptn_Sinc_Relojes";
            this.sptn_Sinc_Relojes.Size = new System.Drawing.Size(59, 52);
            this.sptn_Sinc_Relojes.TabIndex = 1;
            this.sptn_Sinc_Relojes.ToolTip = "Obtener los trabajadores de los dispositivos ";
            this.sptn_Sinc_Relojes.Click += new System.EventHandler(this.sptn_Sinc_Relojes_Click);
            // 
            // sbtn_Cargar_All_Trabajadores
            // 
            this.sbtn_Cargar_All_Trabajadores.Dock = System.Windows.Forms.DockStyle.Top;
            this.sbtn_Cargar_All_Trabajadores.ImageOptions.Image = global::ooc_gest_Reloj.Properties.Resources.get_relojes_48x41;
            this.sbtn_Cargar_All_Trabajadores.Location = new System.Drawing.Point(2, 2);
            this.sbtn_Cargar_All_Trabajadores.Name = "sbtn_Cargar_All_Trabajadores";
            this.sbtn_Cargar_All_Trabajadores.Size = new System.Drawing.Size(59, 52);
            this.sbtn_Cargar_All_Trabajadores.TabIndex = 0;
            this.sbtn_Cargar_All_Trabajadores.ToolTip = "Obtener los trabajadores de los dispositivos ";
            this.sbtn_Cargar_All_Trabajadores.Click += new System.EventHandler(this.sbtn_Cargar_All_Trabajadores_Click);
            // 
            // pc_Relojes
            // 
            this.pc_Relojes.Controls.Add(this.ribbonStatusBar1);
            this.pc_Relojes.Controls.Add(this.lst_Bien);
            this.pc_Relojes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pc_Relojes.Location = new System.Drawing.Point(2, 23);
            this.pc_Relojes.Name = "pc_Relojes";
            this.pc_Relojes.Size = new System.Drawing.Size(139, 676);
            this.pc_Relojes.TabIndex = 0;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(2, 636);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Size = new System.Drawing.Size(135, 20);
            // 
            // lst_Bien
            // 
            this.lst_Bien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lst_Bien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lst_Bien.HideSelection = false;
            this.lst_Bien.Location = new System.Drawing.Point(2, 656);
            this.lst_Bien.Name = "lst_Bien";
            this.lst_Bien.Size = new System.Drawing.Size(135, 18);
            this.lst_Bien.TabIndex = 4;
            this.lst_Bien.UseCompatibleStateImageBehavior = false;
            this.lst_Bien.View = System.Windows.Forms.View.List;
            // 
            // gc_Trabajadoreso
            // 
            this.gc_Trabajadoreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Trabajadoreso.Location = new System.Drawing.Point(0, 15);
            this.gc_Trabajadoreso.MainView = this.gridView1;
            this.gc_Trabajadoreso.Name = "gc_Trabajadoreso";
            this.gc_Trabajadoreso.Size = new System.Drawing.Size(1083, 664);
            this.gc_Trabajadoreso.TabIndex = 14;
            this.gc_Trabajadoreso.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gc_Trabajadoreso.Click += new System.EventHandler(this.gc_Trabajadoreso_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gc_Trabajadoreso;
            this.gridView1.Name = "gridView1";
            // 
            // lb_Barra_estado
            // 
            this.lb_Barra_estado.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Barra_estado.Appearance.Options.UseFont = true;
            this.lb_Barra_estado.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_Barra_estado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_Barra_estado.Location = new System.Drawing.Point(0, 679);
            this.lb_Barra_estado.Name = "lb_Barra_estado";
            this.lb_Barra_estado.Size = new System.Drawing.Size(1083, 22);
            this.lb_Barra_estado.TabIndex = 13;
            this.lb_Barra_estado.Text = "labelControl1";
            // 
            // lst_fallos
            // 
            this.lst_fallos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lst_fallos.Dock = System.Windows.Forms.DockStyle.Right;
            this.lst_fallos.HideSelection = false;
            this.lst_fallos.Location = new System.Drawing.Point(1083, 15);
            this.lst_fallos.Name = "lst_fallos";
            this.lst_fallos.Size = new System.Drawing.Size(29, 686);
            this.lst_fallos.TabIndex = 11;
            this.lst_fallos.UseCompatibleStateImageBehavior = false;
            this.lst_fallos.View = System.Windows.Forms.View.List;
            this.lst_fallos.Visible = false;
            // 
            // pb_Trabajadores
            // 
            this.pb_Trabajadores.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_Trabajadores.Location = new System.Drawing.Point(0, 0);
            this.pb_Trabajadores.Name = "pb_Trabajadores";
            this.pb_Trabajadores.Size = new System.Drawing.Size(1112, 15);
            this.pb_Trabajadores.TabIndex = 9;
            // 
            // xfrm_GetTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 701);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "xfrm_GetTrabajadores";
            this.Text = "Gest. Trabajadores";
            this.Load += new System.EventHandler(this.xfrm_GetTrabajadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Relojes_Operaciones)).EndInit();
            this.Relojes_Operaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pc_operaciones)).EndInit();
            this.pc_operaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pc_Relojes)).EndInit();
            this.pc_Relojes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Trabajadoreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl Relojes_Operaciones;
        private DevExpress.XtraEditors.PanelControl pc_operaciones;
        private DevExpress.XtraEditors.PanelControl pc_Relojes;
        private DevExpress.XtraEditors.SimpleButton sbtn_Cargar_All_Trabajadores;
        private DevExpress.XtraEditors.SimpleButton sptn_Sinc_Relojes;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ListView lst_Bien;
        private System.Windows.Forms.ListView lst_fallos;
        private System.Windows.Forms.ProgressBar pb_Trabajadores;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.GridControl gc_Trabajadoreso;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lb_Barra_estado;
    }
}