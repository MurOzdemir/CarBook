using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonailResults;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<TestiMonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<TestiMonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
               Name=values.Name,
               Comment=values.Comment,
               ImageUrl=values.ImageUrl,
               Title = values.Title,
               TestiMonialID = values.TestiMonialID

            };  // burada listeme yapılır.
        }
    

    }

}

