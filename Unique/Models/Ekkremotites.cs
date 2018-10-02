using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEkkremotites.Models
{
    public class cEkkremotites
    {
        public int ID { get; set; }
        public string Ekkremotites { get; set; }
        public string Location { get; set; }
    }
}