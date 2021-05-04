using System.ComponentModel.DataAnnotations;

namespace OrderManagement.UseCases.CancelOrder
{
    public class CancelOrderRequest
    {
        [Required]
        [StringLength(1024, MinimumLength = 5)]
        public string Reason { get; set; }
    }
}