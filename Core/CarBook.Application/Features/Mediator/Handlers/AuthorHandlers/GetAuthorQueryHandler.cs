﻿using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Authors.Mediator.Handlers.AuthorHandler
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>> //mediatör kısmında implament edilir.
    {
        private readonly IRepository<Author> _repository;      //generate (yapıcı) metod

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                Name = x.Name,
                Description = x.Description,
                ImageUrl= x.ImageUrl
            }).ToList();  // burada listeme yapılır.
        }
    }
}
