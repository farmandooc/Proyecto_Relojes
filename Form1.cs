using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


#region Mis Usings
using Riss.Devices;
using ooc_gest_Reloj.frm;
using ooc_Extenciones;
using ooc_gest_Reloj.drivers;
using ooc_gest_Reloj.Utiles;

#endregion Mis Usings


namespace ooc_gest_Reloj
{
    public partial class Principal : Form
    {
        static public xfrm_GestDispositivos frm_GestDispositivo = new xfrm_GestDispositivos();
        static public xfrm_SincronizarHoraFecha frm_SincronizarHoraFecha = new xfrm_SincronizarHoraFecha();
        static public xfrm_GetTrabajadores xfrm_GetTrabajadores = new xfrm_GetTrabajadores();


        public BDatos<Device> BD = new BDatos<Device>();
        #region Mis Metodos 
        /// <summary>
        /// este metodo es el encargado de poner (Mostrar) un formulario dentro de un contenedo 
        /// 
        /// </summary>
        /// <param name="frm_"></param>
        public void Show_frmEnContenedor(Form frm_)
        {

            frm_.TopLevel = false;
            p_Escritorio_Contenedor.Controls.Clear();
            p_Escritorio_Contenedor.Controls.Add(frm_);
            frm_.BringToFront();
            frm_.Dock = DockStyle.Fill;
            frm_.ControlBox = false;
            frm_.Show();
        }

        public void Show_frmEnContenedor(DevExpress.XtraEditors.XtraForm frm_)
        {

            frm_.TopLevel = false;
            p_Escritorio_Contenedor.Controls.Clear();
            p_Escritorio_Contenedor.Controls.Add(frm_);
            frm_.BringToFront();
            frm_.Dock = DockStyle.Fill;
            frm_.ControlBox = false;
            frm_.Show();
        }
        public void Mostrar_relojes_Laterales()
        {
            this.relojes.Controls.Clear();
            Util.BD.Cargar();
            Util.Mostrar_relojes_Laterales(relojes);
           
        }
        #endregion


        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BD.Cargar();
            Mostrar_relojes_Laterales();
        }

        private void btn_Add_dispositivo_Click(object sender, EventArgs e)
        {
            frm_GestDispositivo.Padre = this;
            Show_frmEnContenedor(frm_GestDispositivo);
        }

        private void sincronizarHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_frmEnContenedor(frm_SincronizarHoraFecha);
        }

        private void ssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xfrm_GetTrabajadores.Text = "Recojer todos los trabajadores";
            Show_frmEnContenedor(xfrm_GetTrabajadores);
        }
    }
}
