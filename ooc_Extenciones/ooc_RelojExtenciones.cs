using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Mis Usings
using Riss.Devices;
using IConvert;
using SysEnum;
using Entity;
//using ooc_Extenciones;
using ooc_gest_Reloj.drivers;
using Newtonsoft.Json;
using ooc_gest_Reloj.Utiles;
using System.Reflection;
#endregion Mis Usings

namespace ooc_Extenciones
{
    public static class ooc_RelojExtenciones
    {
        //private static String HexConverter(this System.Drawing.Color c)
        //{
        //    return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        //}

        static public bool Es_Igual_A(this User Persona, User Con_esta)
        {
            bool salida = true;
            PropertyInfo[] lst = typeof(User).GetProperties();

            try
            {
                foreach (PropertyInfo Propiedad in lst)
                {
                    var test = Propiedad.Name;
                    var VPersona = Propiedad.GetValue(Persona);
                    var VCon_esta = Propiedad.GetValue(Con_esta);
                    if (VPersona != null && VCon_esta != null)
                    {
                        if (test == "Enrolls")
                        {
                            List<Riss.Devices.Enroll> VP_Enrolls = (List<Riss.Devices.Enroll>)VPersona;
                            List<Riss.Devices.Enroll> VC_Enrolls = (List<Riss.Devices.Enroll>)VCon_esta;

                            foreach (Enroll vp_enroll in VP_Enrolls)
                            {
                                Enroll vc_enroll = VC_Enrolls.Where(x => x.DIN == vp_enroll.DIN).First();

                                if (vc_enroll.Es_Igual_A(vp_enroll) != true)
                                {
                                    return false;
                                }
                            }

                            //if (VP_Enrolls.SequenceEqual(VC_Enrolls) != true)
                            //{
                            //    return false;
                            //}


                        }
                        else
                        {
                            if (!VPersona.Equals(VCon_esta))
                            { return false; }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return salida;

        }
        static public bool Es_Igual_A(this Enroll Persona, Enroll Con_esta)
        {
            bool salida = true;
            PropertyInfo[] lst = typeof(Enroll).GetProperties();

            try
            {
                foreach (PropertyInfo Propiedad in lst)
                {
                    var test = Propiedad.Name;
                    var VPersona = Propiedad.GetValue(Persona);
                    var VCon_esta = Propiedad.GetValue(Con_esta);
                    if (VPersona != null && VCon_esta != null)
                    {
                        if (test == "Fingerprint")
                        {
                            byte[] P_huellas = (byte[])VPersona;
                            byte[] C_huellas = (byte[])VCon_esta;

                            for (int i = 0; i < 4980; i++)
                            {
                                if (P_huellas[i] != C_huellas[i])
                                {
                                    return false;
                                }
                            }

                        }
                        else
                        {

                            if (!VPersona.Equals(VCon_esta))
                            { return false; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return salida;

        }

    }
}
