using CarBook.Application.Features.Mediator.Commands.TestiMonialCommands;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<TestiMonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<TestiMonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)     // cancellationtoken ödeme işlemlerinde ödeme iptaligi gibi bir işlem görüyor.
        {
            await _repository.CreateAsync(new TestiMonial
            {
               Comment = request.Comment,
               ImageUrl = request.ImageUrl,
               Name = request.Name,
               Title = request.Title,
            });
        }
    
    }
}
