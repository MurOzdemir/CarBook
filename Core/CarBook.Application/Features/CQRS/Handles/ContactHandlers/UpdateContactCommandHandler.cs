﻿using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Intefaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handles.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ContactID);
            values.Name = command.Name;
            values.SendDate = command.SendDate;
            values.Email = command.Email;
            values.Subject = command.Subject;
            values.ContactID = command.ContactID;
            await _repository.UpdateAsync(values);
        }
    }
}
 