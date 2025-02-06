using AutoMapper.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Feature.Order.Commands.Create;
using SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId;
using SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll;
using System.Net;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "getOrderByCustomerId")]
        [ProducesResponseType(typeof(IEnumerable<GetOrdersByClientIdMV>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMessage(int customerId)
        {
            var response = await _mediator.Send(new GetOrdersByClientIdQuery(customerId));
            return Ok(response);
        }

        [HttpGet("getSaleDatePrediction")]
        [ProducesResponseType(typeof(IEnumerable<GetAllSalesDatePredictionMV>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSaleDatePrediction()
        {
            var response = await _mediator.Send(new GetAllSalesDatePredictionQuery());
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody] CreateOrderWithDetailsCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
