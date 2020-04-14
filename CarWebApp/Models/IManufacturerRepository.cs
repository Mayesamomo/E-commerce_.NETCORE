using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> GetAllManufacturer();
        Manufacturer GetManufacturerById(int id);
    }
}
