using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OrderManagement.Usecases.GetOrder;

namespace OrderManagement.Presenter
{
    public class GetOrderPresenter : IGetOrderPresenter
    {
        private readonly HttpResponse _httpResponse;

        public GetOrderPresenter(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public void Present(OrderResponseModel order)
        {
            var viewModel = new OrderViewModel {id = order.id, state = order.state};
            var json = JsonConvert.SerializeObject(viewModel);
            var bytes = Encoding.UTF8.GetBytes(json);
            _httpResponse.Body.WriteAsync(bytes);
        }
    }
}