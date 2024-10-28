using CarBook.Application.Features.Mediator.Commands.TestiMonialCommands;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using MediatR;



namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<TestiMonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<TestiMonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TestiMonialID);
            values.Title = request.Title;
            values.Comment = request.Comment;
            values.Name = request.Name;
            values.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
