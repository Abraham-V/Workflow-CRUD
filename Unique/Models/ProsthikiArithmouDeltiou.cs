using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProsthikiArithmouDeltiou.Models
{
    public class ProsthikiArithmouDeltiou
    {
        public int ID { get; set; }        
        public int Number { get; set; }
        public string Location { get; set; }
    }
}
