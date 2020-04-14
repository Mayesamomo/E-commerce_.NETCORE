using CarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.VIewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
    }
}
