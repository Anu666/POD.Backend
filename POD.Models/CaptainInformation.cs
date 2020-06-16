using System;
using System.Collections.Generic;
using System.Text;

namespace POD.Models
{
    public class CaptainInformation
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public LocationData LastKnownLocation { get; set; }
    }
}
