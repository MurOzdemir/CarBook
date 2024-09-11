using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handles.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _Repository;
        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _Repository = repository;
        }
        public async Task handle(CreateAboutCommand command)
        {
            await _Repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl,

            });
        }
    }
}
