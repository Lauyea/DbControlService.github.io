using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbControlService
{
    public class Station
    {
        public int StationId { get; set; }
        public int SN { get; set; }
        public string Model { get; set; }
        public int ProductLot { get; set; }
        public long InTime { get; set; }
        public long OutTime { get; set; }
    }
}