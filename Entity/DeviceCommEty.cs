using System;
using System.Collections.Generic;
using System.Text;
using Riss.Devices;

namespace Entity {
    public class DeviceCommEty {
        public DeviceCommEty() { }

        public DeviceConnection DeviceConnection { get; set; }

        public Device Device { get; set; }
    }
}
