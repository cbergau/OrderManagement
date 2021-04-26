using System.Text;
using Microsoft.AspNetCore.Http;
using OrderManagement.Usecases.GetOrder;

namespace OrderManagement.Presenter
{
    public class GetOrderPresenter : IGetOrderPresenter
    {
        private readonly HttpResponse _httpResponse;
        private OrderViewModel _viewModel;

        public GetOrderPresenter(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public void Present(OrderResponseModel order)
        {
            _viewModel = new OrderViewModel {id = order.id, state = order.state};
            var bytes = Encoding.UTF8.GetBytes("{somejson: 1}");
            _httpResponse.Body.WriteAsync(bytes);
        }
    }
}