using CarWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AppDbContext _appDbContext;
        public ManufacturerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Manufacturer> GetAllManufacturer()
        {
            return _appDbContext.Manufacturers;
        }

        public Manufacturer GetManufacturerById(int id)
        {
            return _appDbContext.Manufacturers.FirstOrDefault(c => c.ManufacturerId== id);
        }
    }
}
