using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Entities;
using OrderManagement.Presenter;
using OrderManagement.Repository;
using OrderManagement.Usecases.CancelOrder;
using OrderManagement.Usecases.GetOrder;
using OrderManagement.Usecases.GetOrders;
using OrderManagement.Usecases.SubmitOrder;

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
            var useCase = new GetOrderInteractor(_repo, presenter);
            
            useCase.Execute(orderId);
        }

        [HttpGet("/orders/cancel/{orderId}")]
        public Order Cancel(string orderId)
        {
            return new CancelOrderInteractor(_repo).Execute(orderId);
        }

        [HttpGet("/orders/submit")]
        public Order Submit()
        {
            return new SubmitOrderInteractor(_repo).Execute();
        }
    }
}