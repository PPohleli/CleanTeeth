using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler
    {
        private readonly IDentalOfficeRepository repository;

        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository)
        {
            this.repository = repository;
        }


        public async Task<Guid> Handle (CreateDentalOfficeCommand command)
        {
            var dentalOffice = new DentalOffice(command.Name);
            await repository.Add(dentalOffice);
            return dentalOffice.Id;
        }
    }
}
