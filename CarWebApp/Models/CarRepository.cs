using CarWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public class CarRepository : ICarRepository
    {
      
        private readonly AppDbContext _appDbContext;
        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _appDbContext.Cars.Include(c => c.Manufacturer);
        }

        public Car GetCarById(int id)
        {
            return _appDbContext.Cars.FirstOrDefault(b => b.CarId == id);
        }
    }
}
