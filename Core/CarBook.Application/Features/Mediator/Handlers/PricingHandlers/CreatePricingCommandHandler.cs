using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Pricings.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)     // cancellationtoken ödeme işlemlerinde ödeme iptaligi gibi bir işlem görüyor.
        {
            await _repository.CreateAsync(new Pricing
            {
                Name = request.Name
            });
            {
            }
        }
    }
}

