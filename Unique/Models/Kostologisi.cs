using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcKostologisi.Models
{
    public class Kostologisi
    {
        public int ID { get; set; }
        public float? ChargeExtra { get; set; }
        public float? ChargeWork { get; set; }
        public string ChargeMethod { get; set; }
        public float? FPA { get; set; }
        public string Location { get; set; }
        public float? Total { get; set; }
    }
}
