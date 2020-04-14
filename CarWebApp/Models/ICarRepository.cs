using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{

    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
    }
}
