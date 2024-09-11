using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handles.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _Repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _Repository = repository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _Repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerID = x.BannerID,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl 

            }).ToList();
        }
    }
}
