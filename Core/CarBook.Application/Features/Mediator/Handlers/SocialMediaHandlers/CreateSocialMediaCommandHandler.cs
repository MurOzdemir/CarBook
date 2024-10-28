using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateTestimonialCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)     // cancellationtoken ödeme işlemlerinde ödeme iptaligi gibi bir işlem görüyor.
        {
            await _repository.CreateAsync(new SocialMedia
            {
                Name = request.Name,
                Icon= request.Icon,
                Url = request.Url
            });
        }
    
    }
}
