using CleanTeeth.Application.Contracts.Persistence;
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
        private readonly IUnitOfWork unitOfWork;

        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle (CreateDentalOfficeCommand command)
        {
            var dentalOffice = new DentalOffice(command.Name);

            try
            {
                await repository.Add(dentalOffice);
                await unitOfWork.Commit();
                return dentalOffice.Id;
            }
            catch (Exception)
            {

                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
