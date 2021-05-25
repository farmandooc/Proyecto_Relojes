using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

using ooc_Extenciones;


namespace ooc_gest_Reloj.drivers
{
  
    public class BDatos<T>
    {
      public   List<T> Valores = new List<T>();
        string Sarvar_en;


        public BDatos(string ruta = "./BDatos/BaseD.json")
        {
            Sarvar_en = ruta;
            Cargar();
        }

        public void Guardar()
        {
            string texto = JsonConvert.SerializeObject(Valores,Formatting.Indented);
            File.WriteAllText(Sarvar_en, texto);
        }
        public void Guardar(Encoding Juego_Caracteres)
        {
            string texto = JsonConvert.SerializeObject(Valores,Formatting.Indented);
            File.WriteAllText(Sarvar_en, texto,Juego_Caracteres);
        }
        public void Guardar(string sarvar_en)
        {
            string texto = JsonConvert.SerializeObject(Valores,Formatting.Indented);
            File.WriteAllText(sarvar_en, texto, Encoding.UTF8);
        }
        public void Guardar(string sarvar_en,Encoding Juego_caracters)
        {
            string texto = JsonConvert.SerializeObject(Valores,Formatting.Indented);
            File.WriteAllText(sarvar_en, texto, Encoding.UTF8);
        }


        public void Cargar()
        {
            try
            {

                string Archivo = File.ReadAllText(Sarvar_en);
                Valores = JsonConvert.DeserializeObject<List<T>>(Archivo);

            }
            catch (Exception)
            {


            }
        }
        public void Cargar(string camino)
        {
            string Archivo;
            try
            {
                if (!camino.ooc_EstaNuloVacioEspacio())
                {
                 Archivo = File.ReadAllText(camino);

                }
                else
                {

                Archivo = File.ReadAllText(Sarvar_en);
                }
                Valores = JsonConvert.DeserializeObject<List<T>>(Archivo);

            }
            catch (Exception)
            {


            }
        }

        public void Insertar(T nuevo)
        {
            Valores.Add(nuevo);
            Guardar();
        }

        public List<T> Buscar(Func<T, bool> Criterio)
        {
            return Valores.Where(Criterio).ToList();
        }

        public void Eliminar(Func<T, bool> Criterio)
        {
            Valores = Valores.Where(x => !Criterio(x)).ToList();
        }

        public void Actualizar(Func<T, bool> Criterio, T nuevo)
        {
            Valores = Valores.Select(x =>
            {
                {
                    if (Criterio(x)) x = nuevo;
                    return x;
                }
            }).ToList();
        }

    }
}
