using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handles.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _Repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _Repository = repository;
        }
        public async Task <List<GetAboutQueryResult>> Handle()
        {
            var values = await _Repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult 
            { 
                AboutID = x.AboutID,
                Description = x.Description,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
            }
            ).ToList();

        }
    }
   
}
