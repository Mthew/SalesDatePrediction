using AutoMapper.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId;

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

        [HttpGet(Name = "GetOrder")]
        public async Task<IActionResult> GetMessage(int clientId)
        {
            var response = await _mediator.Send(new GetOrdersByClientIdQuery(clientId));
            return Ok(response);
        }
    }
}
