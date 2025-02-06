using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Feature.Employee.Queries.GetAll;
using SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll;
using System.Net;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllEmployeeVM>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMessage()
        {
            var response = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(response);
        }
    }
}
