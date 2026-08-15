using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler : IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        private readonly IDentalOfficeRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IValidator<CreateDentalOfficeCommand> validator;

        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork, IValidator<CreateDentalOfficeCommand> validator)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.validator = validator;
        }
        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            // Implement the logic to create a dental office here
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                // Throw acustom exception
                throw new CustomValidationException(validationResult);
            }

            var dentalOffice = new DentalOffice(command.Name);

            try
            {
                var result = await repository.Add(dentalOffice);
                await unitOfWork.Commit();

                return result.Id;

            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
