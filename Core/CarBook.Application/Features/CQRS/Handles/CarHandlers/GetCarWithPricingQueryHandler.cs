using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Intefaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handles.CarHandlers
{
    public class GetCarWithPricingQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithPricingQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarWithPricingQueryResult> Handle()
        {
            var values = _repository.GetCarWithPricings();
            return values.Select(x => new GetCarWithPricingQueryResult
            {
                Model=x.Car.Model,
                CoverImageUrl=x.Car.CoverImageUrl,
                BrandName=x.Car.Brand.Name,
               PricingAmount=x.Amount
            }).ToList();
        }
    }
}
