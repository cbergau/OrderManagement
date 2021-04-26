using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using OrderManagement.UseCases.CancelOrder;

namespace OrderManagement.Presenter
{
    public class CancelOrderPresenter : ICancelOrderPresenter
    {
        private readonly HttpResponse _response;

        public CancelOrderPresenter(HttpResponse response)
        {
            _response = response;
        }

        public void PresentSuccess()
        {
            _response.StatusCode = StatusCodes.Status204NoContent;
        }

        public void PresentDomainError(string code)
        {
            _response.StatusCode = StatusCodes.Status400BadRequest;
            _response.Body.WriteAsync(Encoding.UTF8.GetBytes(code));
        }

        public void PresentError()
        {
            _response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}