using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Mis Usings
using Riss.Devices;
using ooc_gest_Reloj.frm;
using ooc_Extenciones;
using ooc_gest_Reloj.drivers;
using ooc_gest_Reloj.Utiles;
using System.Windows.Forms;
using Entity;

#endregion Mis Usings

namespace ooc_gest_Reloj.frm
{
    public partial class xfrm_SincronizarHoraFecha : DevExpress.XtraEditors.XtraForm
    {

        private Device device;
        private DeviceConnection deviceConnection;
        private DeviceCommEty deviceEty;
        public xfrm_SincronizarHoraFecha()
        {
            InitializeComponent();
            deviceEty = Util.RelojEty;

        }



        private void xfrm_SincronizarHoraFecha_Load(object sender, EventArgs e)
        {
            Util.BD.Cargar();
            Util.Mostrar_relojes_Laterales(panelControl2);
        }

        private void sbtn_Aceptar_Click(object sender, EventArgs e)
        {
            obteniendo_FechasHoras();

            Estableciendo_fechasHoras();
        }







        #region Mis metodos 

        #region Fechas Horas 
        /// <summary>
        /// Este metodo es para obtener la fecha y horas de todos los dispositivos selesccionados 
        /// enla lista
        /// </summary>
        /// <param name="salida"> especifica si va a mostrar un mensage con las horas capturadas o no </param>
        private void obteniendo_FechasHoras(bool salida = false)
        {
            ///seleccionar los que estan con el checkbox en true 
            ///

            List<string> Objetivos = panelControl2.Controls.OfType<CheckBox>().Where(x => x.Checked == true).Select(x => x.Text).ToList();


            /// TEST 
            /// 

            string sms = "";
            foreach (string R_Actual in Objetivos)
            {
                try
                {
                    var resultado = Util.BD.Buscar(x => x.Label == R_Actual).ToArray();
                    Device Dispositivo = resultado[0];

                    object extraProperty = new object();
                    object extraData = new object();
                    /// testing 

                    Util.Conectar_A_Reloj(Dispositivo.DN, Dispositivo.IpAddress, Dispositivo.Label, Dispositivo.IpPort);
                    device = Util.RelojEty.Device;
                    deviceConnection = Util.RelojEty.DeviceConnection;

                    Util.ReloConeccion = DeviceConnection.CreateConnection(ref Util.tmp_reloj);

                    bool result = deviceConnection.GetProperty(DeviceProperty.DeviceTime, extraProperty, ref device, ref extraData);
                    if (result)
                    {
                        DateTime dt = (DateTime)extraData;
                        sms += $"{R_Actual} => {dt.ToString("yyyy-MM-dd HH:mm:ss")}\n";
                    }
                    else
                    {
                        MessageBox.Show($"Fallo al Obtener la Hora de reloj {R_Actual}", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (Exception)
                {


                }
                //Util.Conectar_A_Reloj()

            }

            if (salida)
            {

                MessageBox.Show(sms);
            }
        }

        private bool Estableciendo_fechasHoras()
        {
                bool salida = true; 
            ///seleccionar los que estan con el checkbox en true 
            ///

            List<string> Objetivos = panelControl2.Controls.OfType<CheckBox>().Where(x => x.Checked == true).Select(x => x.Text).ToList();
            foreach (string R_Actual in Objetivos)
            {
                try
                {
                   


                    var resultado = Util.BD.Buscar(x => x.Label == R_Actual).ToArray();
                    Device Dispositivo = resultado[0];

                    object extraProperty = new object();
                    object extraData = new object();
                    /// testing 

                    Util.Conectar_A_Reloj(Dispositivo.DN, Dispositivo.IpAddress, Dispositivo.Label, Dispositivo.IpPort);
                    device = Util.RelojEty.Device;
                    deviceConnection = Util.RelojEty.DeviceConnection;

                    Util.ReloConeccion = DeviceConnection.CreateConnection(ref Util.tmp_reloj);

                    /// para cambiar al hora del sistema es necesario ejecutar con 
                    /// privilegios administrativos 
                    /// en cualquier caso eso era solo para probar y funciono
                    /// 


                    //Util.Cambiar_hora(DateTime.Now,0,Dispositivo.DN,-1);
                    estableciendo_fechaHora();

                }
                catch (Exception)
                {

                    salida = false;
                }
            }

                return salida;
        }

        private void estableciendo_fechaHora(string fecha_hora = "")
        {
            try
            {
                object extraProperty = new object();
                object extraData = new object();
                bool result = deviceConnection.SetProperty(DeviceProperty.DeviceTime, extraProperty, device, extraData);
                if (result)
                {
                    MessageBox.Show($"Reloj {device.Label} sincronizado ", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btn_TimeGet_Click(btn_TimeGet, e);
                }
                else
                {
                    MessageBox.Show($"El reloj {device.Label} no pudo sincronizarse", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Fechas Horas 



        #endregion Mis Metodos 
    }
}