﻿using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandler
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)     // cancellationtoken ödeme işlemlerinde ödeme iptaligi gibi bir işlem görüyor.
        {
            await _repository.CreateAsync(new Feature
            {
               Name = request.Name
            });
        }
    }
}
