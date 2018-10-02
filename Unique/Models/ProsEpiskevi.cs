using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProsEpiskevi.Models
{
    public class cProsEpiskevi
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd, d/M/yy}", ApplyFormatInEditMode = false)]
        public DateTime? FixDate { get; set; }
        public string Location { get; set; }
    }
}

