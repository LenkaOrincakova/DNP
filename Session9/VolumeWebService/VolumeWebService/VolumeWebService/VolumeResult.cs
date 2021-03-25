using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolumeWebService
{
    public class VolumeResult
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Height { get; set; }
        public double Radius { get; set; }
        public double Volume { get; set; }

    }
}
