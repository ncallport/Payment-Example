
namespace Models.PaymentExample.Models
{
    public class TransactionResponseModel
    {

        public ReceiptModel Receipt { get; set; }
        public ErrorModel Error { get; set; }
        public bool HasError { get; set; }

    }
}
