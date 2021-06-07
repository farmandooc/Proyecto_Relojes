using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ooc_gest_Reloj.drivers;
using ooc_Extenciones;
using System.Windows.Forms;
/// Dependencias propias del reloj 
using Riss.Devices;
using IConvert;
using SysEnum;
using Entity;
using System.Runtime.InteropServices;

namespace ooc_gest_Reloj.Utiles
{
    public static class Util
    {

        public static BDatos<Device> BD = new BDatos<Device>();
        public static Device tmp_reloj;
        public static DeviceConnection ReloConeccion;
        public static DeviceCommEty RelojEty;
        public static Zd2911EnrollFileManagement Usuarios_A_ficheros;

        static Util()
        {
            Usuarios_A_ficheros = new Zd2911EnrollFileManagement();
        }
        public static void Mostrar_relojes_Laterales(Panel PContenedor)
        {
            PContenedor.Controls.Clear();
            Util.BD.Cargar();
            foreach (Device reloj in Util.BD.Valores)
            {
                CheckBox tmp_reloj = new CheckBox();
                tmp_reloj.AutoSize = true;
                tmp_reloj.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
                tmp_reloj.Dock = System.Windows.Forms.DockStyle.Top;
                tmp_reloj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                tmp_reloj.Image = global::ooc_gest_Reloj.Properties.Resources.ico_alpha_Clock_32x32;
                tmp_reloj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                tmp_reloj.Location = new System.Drawing.Point(2, 63);
                tmp_reloj.MinimumSize = new System.Drawing.Size(0, 40);
                tmp_reloj.Name = reloj.Label;
                tmp_reloj.Size = new System.Drawing.Size(117, 40);
                tmp_reloj.TabIndex = 2;
                tmp_reloj.Text = reloj.Label;
                tmp_reloj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                tmp_reloj.UseVisualStyleBackColor = true;

                PContenedor.Controls.Add(tmp_reloj);
                Application.DoEvents();
            }
        }

        public static void Mostrar_relojes_Laterales(DevExpress.XtraEditors.PanelControl PContenedor)
        {
            PContenedor.Controls.Clear();
            Util.BD.Cargar();
            foreach (Device reloj in Util.BD.Valores)
            {
                CheckBox tmp_reloj = new CheckBox();
                tmp_reloj.AutoSize = true;
                tmp_reloj.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
                tmp_reloj.Dock = System.Windows.Forms.DockStyle.Top;
                tmp_reloj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                tmp_reloj.Image = global::ooc_gest_Reloj.Properties.Resources.ico_alpha_Clock_32x32;
                tmp_reloj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                tmp_reloj.Location = new System.Drawing.Point(2, 63);
                tmp_reloj.MinimumSize = new System.Drawing.Size(0, 40);
                tmp_reloj.Name = reloj.Label;
                tmp_reloj.Size = new System.Drawing.Size(117, 40);
                tmp_reloj.TabIndex = 2;
                tmp_reloj.Text = reloj.Label;
                tmp_reloj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                tmp_reloj.UseVisualStyleBackColor = true;

                PContenedor.Controls.Add(tmp_reloj);
                Application.DoEvents();
            }
        }

        public static bool Salvar_trabajadores_local(List<User> Lst_usuarios, string Camino = "./BDatos/Salvas.fps")
        {
            //bool salida = true;
            try
            {
                Usuarios_A_ficheros.SaveAllUserEnrollDataAsDB(Camino, Lst_usuarios);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public static DeviceCommEty Conectar_A_Reloj( string Ip, int ID, string Etiqueta = "", string Clave = "0", int Puerto = 5500)
        {
            try
            {


                tmp_reloj = new Device();
                tmp_reloj.DN = ID;
                tmp_reloj.Password = (Clave.ooc_EstaNuloVacioEspacio()) ? "0" : Clave;
                tmp_reloj.Label = (Etiqueta.ooc_EstaNuloVacioEspacio()) ? Ip : Etiqueta;
                tmp_reloj.Model = "ZDC2911";
                tmp_reloj.ConnectionModel = 5;



                if (string.IsNullOrEmpty(Ip.Trim()))
                {
                    MessageBox.Show("Inserte Una direccion IP", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return new DeviceCommEty();
                }

                if (false == ConvertObject.IsCorrenctIP(Ip.Trim()))
                {
                    MessageBox.Show("direccion IP no Validad", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return new DeviceCommEty(); ;
                }

                tmp_reloj.IpAddress = Ip.Trim();
                tmp_reloj.IpPort = Puerto;
                tmp_reloj.CommunicationType = CommunicationType.Tcp;



                ReloConeccion = DeviceConnection.CreateConnection(ref tmp_reloj);
                if (ReloConeccion.Open() > 0)
                {
                    RelojEty = new DeviceCommEty();
                    RelojEty.Device = tmp_reloj;
                    RelojEty.DeviceConnection = ReloConeccion;

                }

                return RelojEty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de coneccion", ex.Message);
                return new DeviceCommEty();

            }
        }
        /// <summary>
        /// recordar las propiedades del Usuario o trabajador 
        /// ===========================================================================================
        /// shareUser.DIN = (UInt64)nud_DIN.Value;
        /// shareUser.Privilege = GetPrivilege();
        /// shareUser.Enrolls[0].DIN = shareUser.DIN;
        /// shareUser.Enrolls[0].Password = txt_Pwd.Text;
        /// enrollType += Zd2911Utils.SetBit(0, 10); //password is 10, fp0-fp9, card is 11
        /// shareUser.Enrolls[0].CardID = txt_Card.Text;
        /// enrollType += Zd2911Utils.SetBit(0, 11); //password is 10, fp0-fp9, card is 11
        /// shareUser.Enrolls[0].EnrollType = (EnrollType)enrollType;
        /// shareUser.UserName = txt_UserName.Text;
        /// shareUser.Comment = ExtInfoTextBox.Text;
        /// shareUser.Enable = Convert.ToBoolean(userEnableComboBox.SelectedIndex);
        /// shareUser.AttType = (int)userAttTypeIdNumericUpDown.Value;
        /// shareUser.AccessControl = userAccessControlComboBox.SelectedIndex;
        /// shareUser.AccessTimeZone = (int)userPassZoneNumericUpDown.Value;
        /// shareUser.Department = (int)userDeptIdNumericUpDown.Value;
        /// shareUser.UserGroup = (int)userGroupIdNumericUpDown.Value;
        /// shareUser.ValidityPeriod = Convert.ToBoolean(userValidityPeriodComboBox.SelectedIndex);
        /// shareUser.ValidDate = userStartDateTimePicker.Value;
        /// shareUser.InvalidDate = userEndDateTimePicker.Value;
        /// shareUser.Res = (uint)userResNumericUpDown.Value;
        /// 
        /// 
        /// ___________________________________________________________________________________________
        /// </summary>
        /// <param name="dce"> tipo de dato que guarda la rfelacion entre el dipositivo y la coneccion </param>
        /// <param name="shareUser"> Usuario que guarda la relacion de Trabajadores clase User</param>
        /// <returns></returns>

        public static DeviceCommEty Reloj_Agregar_nuevo_Trabajador(this DeviceCommEty dce, User shareUser, int id_reloj = -0 ,string IP_reloj = "")
        {
            object extraProperty = new object();
            object extraData = new object();
            extraData = false;
            int enrollType = 0;

            try
            {

                /**
                if (shareUser == null)
                {
                    shareUser = new User();
                    shareUser.Enrolls = new List<Enroll>();
                    Enroll enroll = new Enroll();
                    shareUser.Enrolls.Add(enroll);
                }
                shareUser.DIN = (UInt64)22;
                shareUser.Privilege = 0;
                shareUser.Enrolls[0].DIN = shareUser.DIN;
                shareUser.Enrolls[0].Password = "1111";
                enrollType += Zd2911Utils.SetBit(0, 10); //password is 10, fp0-fp9, card is 11
                shareUser.Enrolls[0].CardID = "";
                enrollType += Zd2911Utils.SetBit(0, 11); //password is 10, fp0-fp9, card is 11
                shareUser.Enrolls[0].EnrollType = (EnrollType)enrollType;
                shareUser.UserName = "Probando";
                shareUser.Comment = "Comentario _ 111";
                shareUser.Enable = Convert.ToBoolean(1);
                shareUser.AttType = (int)0;
                shareUser.AccessControl = -1;
                shareUser.AccessTimeZone = (int)0;
                shareUser.Department = (int)0;
                shareUser.UserGroup = (int)0;
                shareUser.ValidityPeriod = Convert.ToBoolean(1);
                shareUser.ValidDate = new System.DateTime(2021,6,7,22,05,24);
                shareUser.InvalidDate = new System.DateTime(2021, 6, 7, 21, 05, 24); ;
                shareUser.Res = (uint)0;
                */
               

                DeviceCommEty dc = Util.Conectar_A_Reloj(dce.Device.IpAddress,dce.Device.DN,dce.Device.Label);

                DeviceConnection deviceConnection = dc.DeviceConnection;
                bool result = deviceConnection.SetProperty(UserProperty.Enroll, extraProperty, shareUser, extraData);
                if (false == result)
                {
                    MessageBox.Show("Fallo", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new DeviceCommEty();
                }

                MessageBox.Show("OK", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new DeviceCommEty();
            }
        }


public static int GetPrivilege(int rol)
{
    switch (rol)
    {
        case 0:
            return (int)UserPrivilege.ROLE_GENERAL_USER;

        case 1:
            return (int)UserPrivilege.ROLE_ENROLL_USER;

        case 2:
            return (int)UserPrivilege.ROLE_VIEW_USER;

        case 3:
            return (int)UserPrivilege.ROLE_SUPER_USER;

        case 4:
            return (int)UserPrivilege.ROLE_CUSTOMER;
    }

    return 0;
}
public static bool Conectar_A_Reloj(int ID, string IP, string Etiketa = "", int Puerto = 5500, string Clave = "0")
{
    try
    {


        tmp_reloj = new Device();
        tmp_reloj.DN = ID;
        tmp_reloj.Password = (Clave.ooc_EstaNuloVacioEspacio()) ? "0" : Clave;
        tmp_reloj.Label = (Etiketa.ooc_EstaNuloVacioEspacio()) ? IP : Etiketa;
        tmp_reloj.Model = "ZDC2911";
        tmp_reloj.ConnectionModel = 5;



        if (string.IsNullOrEmpty(IP.Trim()))
        {
            MessageBox.Show("Inserte Una direccion IP", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //IP.Focus();
            return false;
        }

        if (false == ConvertObject.IsCorrenctIP(IP.Trim()))
        {
            MessageBox.Show("direccion IP no Validad", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //te_IpAddrs.Focus();
            return false;
        }

        tmp_reloj.IpAddress = IP.Trim();
        tmp_reloj.IpPort = Puerto;
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
public static Boolean Cerrar_coneccion()
{

    try
    {
        Util.RelojEty.DeviceConnection.Close();
        Util.ReloConeccion.Close();

        Util.RelojEty.Device = null;
        Util.RelojEty.DeviceConnection = null;
        Util.RelojEty = null;
    }
    catch (Exception)
    {

        return false;
    }
    return true;
}

//// Esto es extra para cambiar la hora del sistema 
/// <summary>
/// 
/// 
/// </summary>
public static void Cambiar_hora(DateTime ServerDateTime, int dia = 0, int Mes = 0, int annos = 0)
{
    if (dia != 0) { ServerDateTime = ServerDateTime.AddDays(dia); }
    if (Mes != 0) { ServerDateTime = ServerDateTime.AddMonths(Mes); }
    if (annos != 0) { ServerDateTime = ServerDateTime.AddYears(annos); }


    SYSTEMTIME st = new SYSTEMTIME();
    st.wYear = (short)ServerDateTime.Year; // must be short
    st.wMonth = (short)ServerDateTime.Month;
    st.wDay = (short)ServerDateTime.Day;
    st.wHour = (short)ServerDateTime.Hour;
    st.wMinute = (short)ServerDateTime.Minute;
    st.wSecond = (short)ServerDateTime.Second;
    st.wMilliseconds = (short)ServerDateTime.Millisecond;
    SetSystemTime(ref st);

}


[DllImport("kernel32.dll", SetLastError = true)]
public static extern bool SetSystemTime(ref SYSTEMTIME st);


    }


   

    // [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
{
    public short wYear;
    public short wMonth;
    public short wDayOfWeek;
    public short wDay;
    public short wHour;
    public short wMinute;
    public short wSecond;
    public short wMilliseconds;
}

   
}