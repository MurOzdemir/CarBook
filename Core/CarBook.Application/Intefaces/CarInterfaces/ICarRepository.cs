using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Intefaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrands();
        List<Car> GetLast5CarsWithBrands();
    }
}
