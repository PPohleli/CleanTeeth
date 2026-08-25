using CleanTeeth.API.DTOs.DentalOffices;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/dentaloffices")]
    public class DentalOfficeController : ControllerBase
    {
        private readonly IMediator mediator;

        public DentalOfficeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDentalOfficeDTO createDentalOfficeDTO)
        {
            var command = new CreateDentalOfficeCommand
            {
                Name = createDentalOfficeDTO.Name,
            };

            await mediator.Send(command);

            return Ok();
        }
    }
}
