using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTechnician.Models
{
    public class Technician
    {
        public int ID { get; set; }
        public string ErgasiaTexnikou { get; set; }
        public string UsedExtra { get; set; }
        public float? ChargeExtra { get; set; }
        public float? ChargeWork { get; set; }
        public string ExtraNotes { get; set; }
        public string Location { get; set; }
    }
}