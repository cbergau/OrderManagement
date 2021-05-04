using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.UseCases.CancelOrder
{
    public interface ICancelOrderPresenter
    {
        public void PresentSuccess();
        public void PresentDomainError(string errorId);
        public void PresentError();
        public void PresentValidationErrors(List<ValidationResult> validationResults);
    }
}