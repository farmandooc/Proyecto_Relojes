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
using ooc_gest_Reloj.frm;


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
    public partial class xfrm_GetTrabajadores : frm_Plantilla
    {
        ListView lvw_UserList = new ListView();
        BDatos<User> BDTrabajadores = new BDatos<User>("./BDatos/BDTrabajadores.json");
        string Titulo = "";
        public xfrm_GetTrabajadores()
        {
            InitializeComponent();
        }

        private void xfrm_GetTrabajadores_Load(object sender, EventArgs e)
        {
            Util.Mostrar_relojes_Laterales(pc_Relojes);
            this.Titulo = this.Text;
            Cargar_inf_Local();
            Asignacion_event_dinamica();



        }

        private void sbtn_Cargar_All_Trabajadores_Click(object sender, EventArgs e)
        {
            List<string> Objetivos = pc_Relojes.Controls.OfType<CheckBox>().Where(x => x.Checked == true).Select(x => x.Text).ToList();
            int Intentos = 0;
            string tmp_tit = Titulo;
            foreach (string reloj in Objetivos)
            {

                Obtener_datos_de_un_reloj(reloj);
                Titulo = tmp_tit;

            }
        }


        #region Mis Metodos 
        public void Obtener_datos_de_un_reloj(string reloj)
        {

            pb_Trabajadores.Value = 0;
            object extraProperty = new object();
            object extraData = new object();
            extraData = Global.DeviceBusy;


            var resultado = Util.BD.Buscar(x => x.Label == reloj).ToArray();
            Device Dispositivo = resultado[0];
            this.Text = $"{Titulo} |{reloj} -> {Dispositivo.IpAddress}";
            Util.Conectar_A_Reloj(Dispositivo.DN, Dispositivo.IpAddress, Dispositivo.Label, Dispositivo.IpPort);
            device = Util.RelojEty.Device;
            deviceConnection = Util.RelojEty.DeviceConnection;
            Util.ReloConeccion = DeviceConnection.CreateConnection(ref Util.tmp_reloj);
            bool Estado_error = false;

            try
            {
                bool result = deviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);
                extraProperty = (UInt64)0;
                result = deviceConnection.GetProperty(DeviceProperty.Enrolls, extraProperty, ref device, ref extraData);
                if (false == result)
                {
                    MessageBox.Show("Get All Enroll Data Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int no = 1;
                List<User> userList = (List<User>)extraData;
                List<User> Mi_userList = new List<User>();


                pb_Trabajadores.Maximum = userList.Count;
                foreach (User user in userList)
                {
                    pb_Trabajadores.Value++;
                    pb_Trabajadores.ForeColor = Color.DarkSeaGreen;

                    Application.DoEvents();
                    Enroll enroll = user.Enrolls[0];
                    ListViewItem item = new ListViewItem(no.ToString());
                    var Credencial = user.DIN.ToString();

                    pb_Trabajadores.Text = $"Trabajador: {Credencial}";
                    item.SubItems.Add(user.DIN.ToString());
                    int intento = 0;

                    User u = user;
                reintentar:
                    result = deviceConnection.GetProperty(UserProperty.Enroll, extraProperty, ref u, ref extraData);

                    if (false == result)
                    {
                        lst_fallos.Items.Add(Credencial.ToString());



                        //MessageBox.Show("Get All Enroll Data Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (Util.Cerrar_coneccion())

                        {

                            //MessageBox.Show("Reconectando", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            Util.Conectar_A_Reloj(Dispositivo.DN, Dispositivo.IpAddress, Dispositivo.Label, Dispositivo.IpPort);
                            device = Util.RelojEty.Device;
                            deviceConnection = Util.RelojEty.DeviceConnection;
                            Util.ReloConeccion = DeviceConnection.CreateConnection(ref Util.tmp_reloj);
                            if (intento == 0)
                            {
                                intento++;
                                pb_Trabajadores.ForeColor = Color.Red;
                                this.Text = $"{Titulo}: la coneccion Falló Intento No.: {intento} credencial: {Credencial}";
                                Application.DoEvents();
                                goto reintentar;
                            }
                            else
                            {
                                intento = 0;
                                continue;

                            }
                        }



                        // return;
                    }


                    pb_Trabajadores.ForeColor = Color.GreenYellow;
                    // this.Text = Titulo;
                    Application.DoEvents();

                    //pb_Trabajadores.Text = $"Trab: {Credencial} Int. : {intento}";

                    for (int i = 0; i < Zd2911Utils.MaxFingerprintCount; i++)
                    {
                        if (0 != Zd2911Utils.BitCheck((int)enroll.EnrollType, i))
                        {
                            item.SubItems.Add("Y");
                        }
                        else
                        {
                            item.SubItems.Add("N");
                        }
                    }

                    if (0 != Zd2911Utils.BitCheck((int)enroll.EnrollType, 10))
                    {
                        item.SubItems.Add("Y");
                    }
                    else
                    {
                        item.SubItems.Add("N");
                    }

                    if (0 != Zd2911Utils.BitCheck((int)enroll.EnrollType, 11))
                    {
                        item.SubItems.Add("Y");
                    }
                    else
                    {
                        item.SubItems.Add("N");
                    }
                    string userPrivilege = ConvertObject.GetUserPrivilege((UserPrivilege)user.Privilege);
                    item.SubItems.Add(userPrivilege);
                    item.Tag = u;
                    lvw_UserList.Items.Add(item);
                    no++;

                    gc_Trabajadoreso.DataSource = userList;
                    lst_Bien.Items.Add($"{Credencial} -=> {u.UserName}");
                    var Nombre_usuario = u.UserName.ToString();
                }

                BDTrabajadores.Valores = userList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gc_Trabajadoreso.Refresh();
                extraData = Global.DeviceIdle;
                deviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);


                BDTrabajadores.Guardar($"./BDatos/{reloj}.json", Encoding.UTF8);
            }


        }


        public void Cargar_inf_Local()
        {

            foreach (string reloj in Util.BD.Valores.Select(x => x.Label))
            {
                BDatos<User> tmp_bd = new BDatos<User>($"./BDatos/{reloj}.json");
                tmp_bd.Cargar();
                //tmp_bd.Guardar();
                Almacen.Dispositivos_en_cache.Add(reloj, tmp_bd);
            }
        }
        public void Asignar_Evento_(CheckBox chb)
        {

            chb.Click += new System.EventHandler(Evento_dinamico_clik_derecho);

        }
        public void Evento_dinamico_clik_derecho(object sender, EventArgs e)
        {
            CheckBox chb = (CheckBox)sender;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                chb.Checked = !chb.Checked;
                try
                {

                    if (Almacen.Dispositivos_en_cache[chb.Text].Valores.Count > 0)
                    {
                        gc_Trabajadoreso.DataSource = Almacen.Dispositivos_en_cache[chb.Text].Valores;
                        Util.Salvar_trabajadores_local(Almacen.Dispositivos_en_cache[chb.Text].Valores, $"./BDatos/{chb.Text}.fps");
                    }
                    else
                    {
                        MessageBox.Show($"el Dispositivo  {chb.Text} No tiene informacion almacenada loscalmente ", "Error ");

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show($"el Dispositivo  {chb.Text} No tiene informacion almacenada loscalmente ", "Error ");
                }
            }


        }


        public void Asignacion_event_dinamica()
        {
            foreach (CheckBox tmp_control in pc_Relojes.Controls.OfType<CheckBox>())
            {
                Asignar_Evento_(tmp_control);
            }
        }
        #endregion Mis metodos 

        private void pc_operaciones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}