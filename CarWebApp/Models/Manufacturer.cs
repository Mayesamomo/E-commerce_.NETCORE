using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string Description { get; set; }
        public List<Car> Cars{ get; set; }
    }
}
