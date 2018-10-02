using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPromitheftes.Models
{
    public class cPromitheftes
    {
        public int ID { get; set; }
        public string Promitheftes { get; set; }
        public string Location { get; set; }
    }
}
