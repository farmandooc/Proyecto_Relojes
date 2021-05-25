using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using Newtonsoft.Json;

namespace ooc_Extenciones
{
    public static class MisExtenciones
    {
        static ArrayList Controles = new ArrayList();

        #region Colores
        public static string ToHex(this Color color)
        {
            return String.Format("#{0}{1}{2}{3}"
                , color.A.ToString("X").Length == 1 ? String.Format("0{0}", color.A.ToString("X")) : color.A.ToString("X")
                , color.R.ToString("X").Length == 1 ? String.Format("0{0}", color.R.ToString("X")) : color.R.ToString("X")
                , color.G.ToString("X").Length == 1 ? String.Format("0{0}", color.G.ToString("X")) : color.G.ToString("X")
                , color.B.ToString("X").Length == 1 ? String.Format("0{0}", color.B.ToString("X")) : color.B.ToString("X"));
        }



        private static String HexConverter(this System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private static String RGBConverter(this System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }


        public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        // fuente : https://stackoverflow.com/questions/2395438/convert-system-drawing-color-to-rgb-and-hex-value
        public static string ToRgbString(this Color c) => $"RGB({c.R}, {c.G}, {c.B})";
        public static string A_RgbString(this Color c) => $"{c.R}, {c.G}, {c.B}";


        /*
        extraido de :
         https://supportcenter.devexpress.com/ticket/details/t462731/progressbarcontrol-how-to-set-a-custom-display-text
         y lo he modificado un poco
         */
        public static void Increment(this ProgressBarControl edit, int val, string displayText)
        {

            edit.Increment(val);
            edit.CustomDisplayText += (sender, args) => {
                args.DisplayText = string.Format("{0} {1}%", displayText, args.Value);
            };
            Application.DoEvents();
        }

        #endregion

        #region   Numeros


        static public float ooc_toFloat(this Decimal D)
        {
            if (D <= 0)
            {
                D = 1;
            }
            return (float)Convert.ChangeType(D, typeof(float));
        }
        #endregion


        #region Controles

        static public ArrayList ooc_getGontroles(this Control C, string tipo = null)
        {

            foreach (Control control in C.Controls)
            {
                if (tipo == null)
                {
                    Controles.Add(control);
                }
                else
                {
                    string[] Tipo_Actual = control.GetType().ToString().Split('.');
                    int cont = Tipo_Actual.Length;

                    if (tipo.ToLower() == Tipo_Actual[cont - 1])
                    {
                        Controles.Add(control);
                    }
                }
                if (control.HasChildren)
                {
                    control.ooc_getGontroles();
                }


            }


            return Controles;
        }


        #endregion


        #region  Textos

        /**
       * el objetivo de esta funcion es obtener un palabra del pricipio o el fin 
       * de un texto 
       * 
       * en dependencia del parametro posision que puede estar en el estado 
       * principo o fin por defecto fin
       * 
       */
        static public string ooc_Base(this string texto, char separador = '.', string posicion = "fin")
        {
            posicion = posicion.ToLower();
            string salida = "";
            switch (posicion)
            {
                case "inicio":
                    salida = texto.Split(separador).First<string>();
                    break;
                default:
                    salida = texto.Split(separador).Last<string>();
                    break;
            }

            return salida;

        }

        static public Int16 ooc_toInteger(this string texto)
        {
            return Convert.ToInt16(texto);
        }

        /// Encripta una cadena
        public static string ooc_Encriptar(this string _cadenaAencriptar, bool Mostrar = false)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);

            result = Convert.ToBase64String(encryted);
            if (Mostrar)
            {
                Console.WriteLine(result.ToString());
            }
            //Console.ReadKey(true);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string ooc_DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        /// <summary>
        /// este metodo es para validar las consultas
        /// eventualmente puede ser enriquesido 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string ooc_parse_query(this string query)
        {
            string salida = null;
            try
            {
                salida = Regex.Replace(query, "'[ ]*null[ ]*'", "NULL", RegexOptions.IgnoreCase);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error al valida la consulta . : \n {ex.InnerException} => {ex.ParamName} -> {ex.Message}");
            }

            return salida;
        }

        
          /// <summary>
        /// Valida si el texto esta en blanco ("") devuelbe true
        /// Valida si el texto esta en blanco (" ") devuelbe true
        /// Valida si el texto esta en Null  devuelbe true
        /// </summary>
        /// <param name="txt"> Texto a valuar</param>
        /// <returns></returns>
        static public bool ooc_EstaNuloVacioEspacio(this string txt)
        {
            if (string.IsNullOrEmpty(txt)) { return true; }
            if (string.IsNullOrWhiteSpace(txt)) { return true; }
            if (string.IsNullOrWhiteSpace(txt.Trim())) { return true; }
            return false;
        }


        static public string[] ooc_split(this string txt,string separador) {
            string[] separadores = { separador}; 

            return txt.Split(separadores, System.StringSplitOptions.RemoveEmptyEntries);

        }
        static public string[] ooc_split(this string txt,string[] separadores) {
            return txt.Split(separadores, System.StringSplitOptions.RemoveEmptyEntries);
        }

        static public string[] ooc_split(this string txt,char separador) {
            return txt.Split(separador);
        }
        static public string[] ooc_split(this string txt,char[] separadores) {
            return txt.Split(separadores);
        }


        #region Validaciones

        #endregion Validaciones 


        #endregion

        #region Colecciones

        /// <summary>
        /// convierte un texto en un ArrayList 
        /// </summary>
        /// <param name="texto">Texto fuente </param>
        /// <param name="separador"> Caracter Utilizado como seperador </param>
        /// <returns> Devuelve un ArrayList</returns>
        static public ArrayList ooc_StringToArraylist(this string texto, char separador = ',')
        {
            ArrayList salida = new ArrayList();


            foreach (string parte in texto.Split(separador))
            {
                salida.Add(parte);
            }
            return salida;
        }

        static public List<object> ooc_StringTolist(this string texto, char separador = ',')
        {
            List<object> salida = new List<object>();

            foreach (string parte in texto.Split(separador))
            {
                salida.Add(parte);
            }
            return salida;
        }
        static public List<string> ooc_StringTolist_String(this string texto, char separador = ',')
        {
            List<string> salida = new List<string>();

            foreach (string parte in texto.Split(separador))
            {
                salida.Add(parte.Trim());
            }
            return salida;
        }

        /// <summary>
        /// esta funcion es la encargada de generar un Diccionario A partir De un texto Dado 
        /// </summary>
        /// <param name="texto"> Texto a procesar </param>
        /// <param name="separador">Caracter Utilizado como separador </param>
        /// <param name="signo_de_asignacion">Caracter Interpretado como Operador de Asignacion </param>
        /// <returns>Devuelve Un diccionario </returns>
        static public Dictionary<string, string> ooc_StringToDiccionario(this string texto, char separador = ',', char signo_de_asignacion = '=')
        {
            Dictionary<string, string> salida = new Dictionary<string, string>();

            foreach (string parte in texto.Split(separador))
            {
                salida.Add(parte.Split(signo_de_asignacion)[0].ToString().Trim(), parte.Split(signo_de_asignacion)[1].ToString().Trim());
            }
            return salida;
        }


        public static List<string> ooc_Resultado_A_Lista(SqlDataReader DR)

        {
            List<string> Salida = new List<string>();
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    string fichero_actual = DR["subdirectory"].ToString();
                    Salida.Add(fichero_actual);
                }
            }
            return Salida;
        }
        public static string ooc_concatenador(this ArrayList piezas, string separador = " , ")
        {
            string salida = "";
            foreach (var element in piezas)
            {
                if (salida == "")
                {
                    salida += element;
                }
                else
                {
                    salida += separador + element;
                }

            }
            return salida;

        }
        public static string ooc_concatenador(this List<string> piezas, string separador = " , ")
        {
            string salida = "";
            foreach (var element in piezas)
            {
                if (salida == "")
                {
                    salida += element;
                }
                else
                {
                    salida += separador + element;
                }

            }
            return salida;

        }

        /// <summary>
        /// Metodos para llevar de datarow (fila) a Diccionario 
        /// </summary>
        /// <param name="fila"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ooc_FilaToDiccionario(this DataRow fila)
        {
            List<string> Columnas = new List<string>();
            Dictionary<string, string> salida = new Dictionary<string, string>();
            foreach (var Columna in fila.Table.Columns)
            {
                Columnas.Add(Columna.ToString());
            }
            foreach (string colum in Columnas)
            {
                salida.Add(colum, fila[colum].ToString());
            }
            return salida;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fila"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ooc_Fila_To_Diccionario(this DataRow fila, List<string> campos = null)
        {
            Dictionary<string, string> dict = fila.Table.Columns
              .Cast<DataColumn>()
              .ToDictionary(c => c.ColumnName, c => fila[c].ToString());
            if (campos != null)
            {

                Dictionary<string, string> filtrado_dict = new Dictionary<string, string>();
                foreach (string item in campos)
                {
                    filtrado_dict.Add(item, fila[item].ToString());
                }
                return filtrado_dict;
            }

            return dict;
        }


        public static DataRow ooc_get_Uno(this SqlDataReader dr, int Pos = 0)
        {
            DataRow salida = null;
            DataTable dt = new DataTable();
            if (dr.HasRows)
            {
                dt.Load(dr);
                if ((dt.Rows.Count - 1) <= Pos)
                {
                    salida = dt.Rows[Pos];
                }
            }

            return salida;
        }


        #region Colecciones
        static public void ooc_Dump(this Object[] Coleccion)
        {
            {
                string json = JsonConvert.SerializeObject(Coleccion);
                Console.WriteLine(json);
            }


        }
        #endregion
        #endregion
    }
}
