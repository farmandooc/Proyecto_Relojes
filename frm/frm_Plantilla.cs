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
    public partial class frm_Plantilla : DevExpress.XtraEditors.XtraForm
    {

        public Device device;
        public DeviceConnection deviceConnection;
        public DeviceCommEty deviceEty;

        public frm_Plantilla()
        {
            InitializeComponent();

        }

        private void frm_Plantilla_Load(object sender, EventArgs e)
        {
            Util.BD.Cargar();
        }
    }
}