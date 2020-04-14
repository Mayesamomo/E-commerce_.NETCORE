using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        public Car Car { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartSessionId { get; set; }
    }
}
