using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Date Released")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Released { get; set; }
        public bool Instock { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
       
    }
}
