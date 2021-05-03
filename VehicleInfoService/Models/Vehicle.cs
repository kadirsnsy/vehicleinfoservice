using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInfoService.Models
{
    public class Vehicle   
    {
        public Int32? VehicleId { get; set; }
        public Int64? IMEI { get; set; }
        public string Plate { get; set; }
        public string VehicleModel { get; set; } 
        public DateTime? LastRecTime { get; set; }
        public Int16? LastSpeed { get; set; }
        public double? LastLat { get; set; }
        public double? LastLong { get; set; } 
    }
}
