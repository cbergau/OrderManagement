using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

        public void PresentDomainError(string errorId)
        {
            _response.StatusCode = StatusCodes.Status400BadRequest;
            _response.Body.WriteAsync(Encoding.UTF8.GetBytes(errorId));
        }

        public void PresentSuccess()
        {
            _response.StatusCode = StatusCodes.Status204NoContent;
        }

        public void PresentError()
        {
            _response.StatusCode = StatusCodes.Status500InternalServerError;
        }

        public void PresentValidationErrors(List<ValidationResult> validationResults)
        {
            var errors = new Dictionary<string, string>();

            validationResults.ForEach(result =>
            {
                var enumerator = result.MemberNames.GetEnumerator()!;
                enumerator.MoveNext();
                errors.Add(enumerator.Current!, result.ErrorMessage);
            });

            var errorsAsJson = JsonConvert.SerializeObject(errors);
            var buffer = Encoding.UTF8.GetBytes(errorsAsJson);
            _response.Body.WriteAsync(buffer);
            _response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}