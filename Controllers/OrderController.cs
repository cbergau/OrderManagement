using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Entities;
using OrderManagement.Repository;
using OrderManagement.Usecases.CancelOrder;
using OrderManagement.Usecases.GetOrder;
using OrderManagement.Usecases.SubmitOrder;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _repo;

        public OrderController(ILogger<OrderController> logger, IOrderRepository repository)
        {
            _logger = logger;
            _repo = repository;
        }

        [HttpGet("/{orderId}")]
        public Order Get(string orderId)
        {
            return new GetOrderInteractor(_repo).Execute(orderId);
        }

        [HttpGet("/cancel/{orderId}")]
        public Order Cancel(string orderId)
        {
            return new CancelOrderInteractor(_repo).Execute(orderId);
        }

        [HttpGet("/submit")]
        public Order Submit()
        {
            return new SubmitOrderInteractor(_repo).Execute();
        }
    }
}
