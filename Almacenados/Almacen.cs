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
using ooc_Extenciones;
using ooc_gest_Reloj.drivers;
using Newtonsoft.Json;
using ooc_gest_Reloj.Utiles;
#endregion Mis Usings



// namespace ooc_gest_Reloj.Almacenados
//{
static public class Almacen
{

   static public Dictionary<string, BDatos<User>> Dispositivos_en_cache = new Dictionary<string, BDatos<User>>();
    static public List<User> Diferencias = new List<User>();


}
//}
