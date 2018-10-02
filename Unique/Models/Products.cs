using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProducts.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int? Number { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd, d/M/yy}", ApplyFormatInEditMode = false)]
        public DateTime? ReceiveDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd, d/M/yy}", ApplyFormatInEditMode = false)]
        public DateTime? FixDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Products { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Send { get; set; }
        public string ExtraParts { get; set; }
        public string ErgasiaTexnikou { get; set; }
        public string UsedExtra { get; set; }
        public float? ChargeExtra { get; set; }
        public float? ChargeWork { get; set; }
        public string ChargeMethod { get; set; }
        public float? FPA { get; set; }
        public string Location { get; set; }
        public string Ekkremotites { get; set; }
        public string Promitheftes { get; set; }
        public float? Total { get; set; }
        public string ExtraNotes { get; set; }
    }
}