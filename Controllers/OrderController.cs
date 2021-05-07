using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Entities;
using OrderManagement.Presenter;
using OrderManagement.Repository;
using OrderManagement.UseCases.CancelOrder;
using OrderManagement.UseCases.GetOrder;
using OrderManagement.UseCases.GetOrders;
using OrderManagement.UseCases.SubmitOrder;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _repo;
        private readonly IHttpContextAccessor _accessor;

        public OrderController(ILogger<OrderController> logger, IOrderRepository repository,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _repo = repository;
            _accessor = httpContextAccessor;
        }

        [HttpGet("/orders")]
        public IEnumerable<Order> GetAll()
        {
            return new GetOrdersInteractor(_repo).Execute();
        }

        [HttpGet("/orders/{orderId}")]
        public void Get(string orderId)
        {
            var presenter = new GetOrderPresenter(_accessor.HttpContext.Response);
            var useCase = new GetOrderUseCase(_repo, presenter);

            useCase.Execute(orderId);
        }

        [HttpPost("/orders/{orderId}/cancel")]
        public void Cancel(string orderId, CancelOrderHttpRequest httpRequest)
        {
            var request = new CancelOrderRequest {Reason = httpRequest.reason};
            var presenter = new CancelOrderPresenter(_accessor.HttpContext.Response);
            var useCase = new CancelOrderUseCase(_repo, presenter);
            
            useCase.Execute(orderId, request);
        }

        [HttpGet("/orders/submit")]
        public Order Submit()
        {
            return new SubmitOrderInteractor(_repo).Execute();
        }
    }

    public class CancelOrderHttpRequest
    {
        public string reason { get; set; }
    }
}