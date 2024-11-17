using CarBook.Application.Intefaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }

        public List<CarPricing> GetCarWithPricings()
        {
            //var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).ToList(); //Car sınıfından brandleri getirerek Carpringsleri listeyip pricingleri sıralar ve listeler.

            var values = _context.CarPricings
        .Include(x => x.Car)              // Car ile ilişkili veriyi getirir.
        .ThenInclude(y => y.Brand)        // Car'ın Brand ile ilişkisini getirir.
        .Include(x => x.pricing)          // CarPricing ile ilişkili Pricing verisini getirir.
        .ToList();
            return values;

        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();     // A'Z ye kadar  ilk 5 sıralama yapsın
            return values;

        }
    }
}
