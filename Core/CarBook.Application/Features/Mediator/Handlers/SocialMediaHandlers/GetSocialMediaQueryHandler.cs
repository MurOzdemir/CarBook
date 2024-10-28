using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetTestimonialQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult
            {
                SocialMediaID = x.SocialMediaID,
                Icon = x.Icon,
                Name = x.Name,
                Url = x.Url
            }).ToList();  // burada listeme yapılır.

        }

    }
}
