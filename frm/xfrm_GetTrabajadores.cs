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
using System.IO;
using System.Threading;
#endregion Mis Usings

namespace ooc_gest_Reloj.frm
{
    public partial class xfrm_GetTrabajadores : frm_Plantilla
    {
        ListView lvw_UserList = new ListView();
        BDatos<User> BDTrabajadores = new BDatos<User>("./BDatos/BDTrabajadores.json");
        static private object Protegido = new object();
        string Titulo = "";
        string Diferencias = $"./BDatos/diferencias.json";
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

            var tareas = new List<Thread>();
            string Titulo_groupBox = Relojes_Operaciones.Text;


            foreach (string reloj in Objetivos)
            {

                Simular_Obtener_datos_de_un_reloj(reloj);


                string Est_Ant = $"./BDatos/{reloj}_Ant.json";
                string Est_Atc = $"./BDatos/{reloj}.json";
                ///Obtener_datos_de_un_reloj(reloj);
                ///
                try
                {

                    /// esto es para simular que ya se trajo la informacion del reloj en cuestion
                    /// 
                  //  Simular_Obtener_datos_de_un_reloj(reloj);
                    
                    Thread Hilo = new Thread(Comparar_Estados);
                    Hilo.Name = reloj;
                    tareas.Add(Hilo);
                    Hilo.Start(reloj);



                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                Titulo = tmp_tit;

            }

            while (tareas.Where(x => x.IsAlive == true).Count() > 0)
            {
                lb_Barra_estado.Text = "comprobando cambios en: ";
                foreach (Thread item in tareas.Where(x => x.IsAlive))
                {
                    lb_Barra_estado.Text += item.Name + "\t";
                }

           //     lb_Barra_estado.Text = $"";
                Application.DoEvents();
                Thread.Sleep(2000);
            }


            lb_Barra_estado.Text = "Tarea completada";
            lb_Barra_estado.BackColor = Color.DarkGray;
            lb_Barra_estado.ForeColor = Color.LightGreen;

            string texto = JsonConvert.SerializeObject(Almacen.Diferencias, Formatting.Indented);
            
            Guardar_diferencias(texto);
            Eliminar_estados_anteriores(tareas);

        }
        public void Eliminar_estados_anteriores(List<Thread> tareas) {
            foreach (Thread tarea in tareas)
            {
                Eliminado_estado_anterior(tarea.Name);
            }
        }

        private void Eliminado_estado_anterior(string name)
        {
            try
            {
                File.Delete($"./BDatos/{name}_Ant.json");
            }
            catch (Exception)
            {

                
            }
        }

        public void Guardar_diferencias(string Dif)
        {
            if (Almacen.Diferencias.Count() != 0)
            {
                if (File.Exists(Diferencias))
                {
                    File.Delete(Diferencias);
                }
                File.WriteAllText(Diferencias, Dif);
            }
        }

        private void Simular_Obtener_datos_de_un_reloj(object reloj)
        {
            string Simulador = $"./BDatos/simulacion_reloj/{reloj}.json";
            string Est_Atc = $"./BDatos/{reloj}.json";
            string Est_Ant = $"./BDatos/{reloj}_Ant.json";
            try
            {

                File.Move(Est_Atc, Est_Ant);/// Renombrando fichero
                File.Copy(Simulador, Est_Atc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Subir_trabajador(Enroll  trabajador)
        {
            
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


        public bool Compara_personas(User Persona1,User Persona2) {
            bool salida = true;
                


            return salida;

        }

        void Comparar_Estados(object reloj)
        {

            string Est_Atc = $"./BDatos/{reloj}.json";
            string Est_Ant = $"./BDatos/{reloj}_Ant.json";
            BDatos<User> REst_Ant = new BDatos<User>(Est_Ant);
            BDatos<User> REst_Act = new BDatos<User>(Est_Atc);
            REst_Ant.Cargar();
            REst_Act.Cargar();


            foreach (User Trab in REst_Ant.Valores)
            {

                try
                {
                    User Trab_Act = REst_Act.Valores.Where(x => x.DIN == Trab.DIN).First<User>();
                    if (!Trab.Es_Igual_A(Trab_Act))
                    {

                        lock (Protegido)
                        {
                            Almacen.Diferencias.Add(Trab_Act);
                        }
                    }

                }
                catch (Exception)
                {


                }
            }

           

            /// Caso numero 1 (Se Agrego Un nuevo trabajador)
            if (REst_Ant.Valores.Count() < REst_Act.Valores.Count())
            {
                List<ulong> Nuevos = (from T in REst_Act.Valores select T.DIN).Except(from t in REst_Ant.Valores select t.DIN).ToList<ulong>();
                foreach (ulong id_nuevo in Nuevos)
                {
                    User U_Actual = REst_Act.Valores.Where(x => x.DIN == id_nuevo).First<User>();

                }


            }
            /// Caso se elimino un trabajador 
            /// Caso se agrego un nuevo trabajador y se elimino otro 
            /// 



        }

        #endregion Fin de Mis metodos 

        private void pc_operaciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gc_Trabajadoreso_Click(object sender, EventArgs e)
        {

        }

        private void sptn_Sinc_Relojes_Click(object sender, EventArgs e)
        {

            object extraProperty = new object();
            object extraData = new object();
            extraData = Global.DeviceBusy;
            


            try
            {
               DeviceCommEty DC =  Util.Conectar_A_Reloj("10.10.10.39",7,"","0");// le paso 3 parametros por que asi la diferencio de la otra sobre carga 
                DC.DeviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);
                object extraProperty_ = new object();
                object extraData_ = new object();
                int enrollType = 0;
                User shareUser = new User();
                shareUser.DIN = (UInt64)27;
                shareUser.UserName = "luis tomasl";
                //bool result = DC.DeviceConnection.SetProperty(UserProperty.UserName, extraProperty_, user, extraData_);
                //// Ejemplo de prueba 
                ///
                Enroll enroll = new Enroll();
                shareUser.Enrolls.Add(enroll);

                //shareUser.DIN = (UInt64)3;
                shareUser.Privilege = 8;// Util.GetPrivilege(3);
                shareUser.Enrolls[0].DIN = shareUser.DIN;
                shareUser.Enrolls[0].Password = "1111";
                enrollType += Zd2911Utils.SetBit(0, 10); //password is 10, fp0-fp9, card is 11
                shareUser.Enrolls[0].CardID = $"";
                enrollType += Zd2911Utils.SetBit(0, 11); //password is 10, fp0-fp9, card is 11
                shareUser.Enrolls[0].EnrollType = (EnrollType)enrollType;
                //shareUser.UserName = txt_UserName.Text;
                shareUser.Comment = $"Usuarios de prueba";
                shareUser.Enable = Convert.ToBoolean(1);
                shareUser.AttType = (int)0;
                shareUser.AccessControl = -1;
                shareUser.AccessTimeZone = (int)0;
                shareUser.Department = (int)0;
                shareUser.UserGroup = (int)0;
                shareUser.ValidityPeriod = Convert.ToBoolean(1);
                //shareUser.ValidDate = userStartDateTimePicker.Value;
                //shareUser.InvalidDate = userEndDateTimePicker.Value;
                shareUser.Res = (uint)0;


                DC.Reloj_Agregar_nuevo_Trabajador(shareUser);


                //if (result)
                //{
                //    MessageBox.Show("Write FP Data Success", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Write FP Data Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //bool result = deviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            Enroll Trabajador = new Enroll();
            /// todo: Subir Informacion (de los trabajadores) A los Relojes Marcados 
            /// 
            /// 
            /// 
            Subir_trabajador(Trabajador);

        }

        
    }
}