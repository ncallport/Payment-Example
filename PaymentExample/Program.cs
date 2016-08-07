using System;
using Services.PaymentExample.Interfaces;
using Services.PaymentExample.Services;

namespace PaymentExample
{
    public class Program
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {

            Log.Info("Console app starting");

            Console.WriteLine("This program sends a payment request to the Judo Payments API");

            Console.WriteLine("Enter Card Number:");
            var cardNumber = Console.ReadLine();

            Console.WriteLine("Enter Expiry Date (MM/YY)");
            var expiry = Console.ReadLine();

            Console.WriteLine("Enter CV2");
            var cv2 = Console.ReadLine();

            Console.WriteLine("Enter Amount");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
                Console.Write("Amount must be valid decimal, please try again: ");

            Console.WriteLine("");
            Console.WriteLine("Please wait while we attempt to route your transaction...");
            Console.WriteLine("");

            ITransactionService transactionService = new TransactionService();

            var transactionResponse = transactionService.FullCardPayment(cardNumber, expiry, cv2, amount);

            if (transactionResponse.HasError)
            {
                // TRANSACTION HAS FAILED WITH AN ERROR
                Console.WriteLine("Transaction Failed");
                Console.WriteLine("With Message - ");
                Console.WriteLine(transactionResponse.Error.Message);
            }
            else
            {
                // TRANSACTION ROUTED TO GATEWAY WITH NO ERRORS
                // CHECK IF TRANSACTION SUCCESSFUL
                var transactionSuccessful = transactionResponse.Receipt.Result == "Success";
                
                Console.WriteLine("Transaction Routed To Gateway");
                Console.WriteLine("With ReceiptId - " + transactionResponse.Receipt.ReceiptId);
                Console.WriteLine("With Result - " + transactionResponse.Receipt.Result);
                Console.WriteLine("With Message - " + transactionResponse.Receipt.Message);
                if (transactionSuccessful)
                {
                    // SUCCESSFUL TRANSACTION SO RETURN CARD TOKEN
                    Console.WriteLine("With Card Token - " + transactionResponse.Receipt.CardDetails.CardToken);
                }
            }

            Console.ReadLine();

            Log.Info("Console app closed");
        }
    }
}
