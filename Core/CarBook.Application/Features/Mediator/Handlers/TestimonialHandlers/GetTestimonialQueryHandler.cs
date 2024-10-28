using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonailResults;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<TestiMonial> _repository;

        public GetTestimonialQueryHandler(IRepository<TestiMonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
               Title = x.Title,
               TestiMonialID=x.TestiMonialID,
               ImageUrl = x.ImageUrl,
               Comment = x.Comment,
               Name = x.Name
            }).ToList();  // burada listeme yapılır.

        }

    }
}
