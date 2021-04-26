namespace OrderManagement.UseCases.CancelOrder
{
    public interface ICancelOrderPresenter
    {
        public void PresentSuccess();
        public void PresentDomainError(string code);
        public void PresentError();
    }
}