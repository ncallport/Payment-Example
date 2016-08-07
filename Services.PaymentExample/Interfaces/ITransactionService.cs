
using Models.PaymentExample.Models;

namespace Services.PaymentExample.Interfaces
{
    public interface ITransactionService
    {
        TransactionResponseModel FullCardPayment(string cardNumber, string expiryDate, string cv2, decimal amount);
    }
}
