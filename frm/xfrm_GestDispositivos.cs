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

#region Mis Usings
using Riss.Devices;
using IConvert;
using SysEnum;
using Entity;

using ooc_Extenciones;
using ooc_gest_Reloj.drivers;


using Newtonsoft.Json;
using ooc_gest_Reloj.drivers;

using ooc_gest_Reloj.Utiles;

#endregion Mis Usings


namespace ooc_gest_Reloj.frm
{
    public partial class xfrm_GestDispositivos : DevExpress.XtraEditors.XtraForm
    {

        public static List<Device> lst_Relojes = new List<Device>();
        public DeviceConnection ReloConeccion;
        public DeviceConnection Relo_Coneccion;
        public DeviceCommEty RelojEty;
        private Device tmp_reloj;
        public BDatos<Device> BD = new BDatos<Device>();
        public Principal Padre;

        string Elemento;


        #region Mis Metodos 
        public bool Conectar_A_Reloj()
        {
            try
            {


                tmp_reloj = new Device();
                tmp_reloj.DN = te_IdDispositivo.Text.ooc_toInteger();
                tmp_reloj.Password = (te_Clave_reloj.Text.ooc_EstaNuloVacioEspacio()) ? "0" : te_Clave_reloj.Text;
                tmp_reloj.Label = (te_Etiqueta.Text.ooc_EstaNuloVacioEspacio()) ? te_IpAddrs.Text : te_Etiqueta.Text;
                tmp_reloj.Model = "ZDC2911";
                tmp_reloj.ConnectionModel = 5;



                if (string.IsNullOrEmpty(te_IpAddrs.Text.Trim()))
                {
                    MessageBox.Show("Inserte Una direccion IP", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    te_IpAddrs.Focus();
                    return false;
                }

                if (false == ConvertObject.IsCorrenctIP(te_IpAddrs.Text.Trim()))
                {
                    MessageBox.Show("direccion IP no Validad", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    te_IpAddrs.Focus();
                    return false;
                }

                tmp_reloj.IpAddress = te_IpAddrs.Text.Trim();
                tmp_reloj.IpPort = te_Puerto.Text.ooc_toInteger();
                tmp_reloj.CommunicationType = CommunicationType.Tcp;



                ReloConeccion = DeviceConnection.CreateConnection(ref tmp_reloj);
                if (ReloConeccion.Open() > 0)
                {
                    RelojEty = new DeviceCommEty();
                    RelojEty.Device = tmp_reloj;
                    RelojEty.DeviceConnection = ReloConeccion;

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de coneccion", ex.Message);
                return false;

            }
        }
        
        private void Mostrar_Datos_relojes()
        {
            BD.Cargar();
            if (BD.Valores.Count > 0)
            {
                gc_Relojes.DataSource = BD.Valores;
            }
            Elemento = "";
            Padre.Mostrar_relojes_Laterales();
        }
        public void Resetear_formulario() {
            Elemento = "";
            ce_Eliminar.Checked = false;
            te_Clave_reloj.Text = "";
            te_Etiqueta.Text = "";
            te_IdDispositivo.Text = "";
            te_IpAddrs.Text = "";
            te_Puerto.Text = "5500";
        }
        #endregion Mis Metodos 

        public xfrm_GestDispositivos()
        {
            InitializeComponent();
        }

        private void sbt_Aceptar_Click(object sender, EventArgs e)
        {
            string Label_como_id;

            if (ce_Eliminar.Checked)
            {
                if (Elemento.ooc_EstaNuloVacioEspacio())
                {
                    return;
                }
                string N_dispositivo = te_Etiqueta.Text;
                int id_dispositivo = te_IdDispositivo.Text.ooc_toInteger();
                BD.Eliminar(x => x.Label == N_dispositivo);
                BD.Guardar();
                Elemento = "";
                Mostrar_Datos_relojes();
                return;
            }


            /// Buscando coincidencias para actualizar
            /// 
            /// Actualiza el elemento 
            if (!Elemento.ooc_EstaNuloVacioEspacio())
            {
                Device Nuevo = new Device();
                Nuevo.Label = te_Etiqueta.Text;
                Nuevo.DN = te_IdDispositivo.Text.ooc_toInteger();
                Nuevo.IpAddress = te_IpAddrs.Text;
                Nuevo.IpPort = te_Puerto.Text.ooc_toInteger();
                Nuevo.Model = "ZDC2911";
                Nuevo.ConnectionModel = 5;
                Nuevo.CommunicationType = CommunicationType.Tcp;
                BD.Actualizar(x => x.Label == Elemento,Nuevo);
                BD.Guardar();
                Mostrar_Datos_relojes();
                return;

            }



            if (Conectar_A_Reloj())
            {
                /// Hacer halgo con el reloj 
                /// 1) Guardar reloj en la base de datos (Datos de coneccion) en la lista de dispositivos 
                /// 
                //lst_Relojes.Add(tmp_reloj);
                BD.Insertar(tmp_reloj);
                BD.Guardar();
                Mostrar_Datos_relojes();


            }


            Resetear_formulario();
        }

        private void xfrm_GestDispositivos_Load(object sender, EventArgs e)
        {
            Mostrar_Datos_relojes();
        }

       

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
            int pos = e.RowHandle;
            DevExpress.XtraGrid.Views.Grid.GridView Vista_actual = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            Elemento = Vista_actual.GetRowCellDisplayText(pos, "Label").ToString();

            te_Etiqueta.Text = Elemento;
            te_IdDispositivo.Text = Vista_actual.GetRowCellDisplayText(pos, "DN").ToString();
            te_IpAddrs.Text = Vista_actual.GetRowCellDisplayText(pos, "IpAddress").ToString();

            /*

              
        DevExpress.XtraGrid.Views.Grid.GridView Vista_actual = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
        string Cod_actual = Vista_actual.GetRowCellDisplayText(pos, "CODIGO_SERVICIO").ToString();
        string cod_actual_Ult8 = Cod_actual.Substring(4, 8);
        string sql_confictos = $"SELECT REFERENCIA,DESCRIPCION FROM {Almacen.BDatos_seleccionada}.dbo.RECAMBIO bde WHERE bde.REFERENCIA LIKE '%{cod_actual_Ult8}' AND BDE.REFERENCIA != '{Cod_actual}'";


        SqlDataReader sdr = Utiles.correr_consulta(sql_confictos);

        if (sdr.HasRows) { lst_Detalle.DataSource = sdr; }



             */
        }

        private void gc_Relojes_Click(object sender, EventArgs e)
        {

        }
    }
}




