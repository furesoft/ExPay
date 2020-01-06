using ExPay.Core.API;
using ExPay.Core.Models;
using Furesoft.Signals;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var channel = Signal.CreateSenderChannel("ExPay");

            var result = Signal.CallMethod<int>(channel, 0x3A1);

            if (result == 1)
            {
                Console.WriteLine("Payment Succeed");
            }

            TestPayment();

            Console.ReadLine();
        }

        private static async void TestPayment()
        {
            object data = null;

            var acceptedPaymentMethods = new[]
{
    new PaymentMethodData("https://pay.microsoft.com/microsoftpay", data)
};

            // Determine which of our accepted payment methods are supported by the customer's payment applications.
            var paymentMediator = new PaymentMediator();
            var supportedPaymentMethods = await paymentMediator.GetSupportedMethodIdsAsync();

            var displayItemsInCart = new List<PaymentItem>
{
    new PaymentItem("Contoso shoes", new PaymentCurrencyAmount(88.00m, "USD")),
    new PaymentItem("Contoso shoelaces", new PaymentCurrencyAmount(0.56m, "USD")),
};

            // Calculate the total value of display items.
            var totalValue = displayItemsInCart.Sum(item => item.Amount.Value);

            // Add items for any/all applicable taxes.
            decimal salesTax = 0.095241M * totalValue;
            var displayItemsTaxes = new[]
            {
    new PaymentItem("Taxes",
    new PaymentCurrencyAmount(salesTax, "USD"))
};

            // Describe the complete list of display items, and total them up.
            var displayItems = displayItemsInCart.Concat(displayItemsTaxes).ToList();
            totalValue = displayItems.Sum(item => Convert.ToDecimal(item.Amount.Value));
            var totalItem = new PaymentItem("Total",
                new PaymentCurrencyAmount(totalValue, "USD"));

            var contosoDiscountValue = Convert.ToDecimal(totalItem.Amount.Value) * -0.05M;
            var displayItemsForContosoCard = new[]
            {
    new PaymentItem("Contoso Card Discount (5%)",
    new PaymentCurrencyAmount(contosoDiscountValue, "USD"))
};

            displayItems.Concat(displayItemsForContosoCard);

            // Re-calculate the total value with discount
            totalValue = displayItemsInCart.Sum(item => Convert.ToDecimal(item.Amount.Value));
            var totalItemForContosoCard = new PaymentItem("Total",
                new PaymentCurrencyAmount(totalValue, "USD"));

            var details = new PaymentDetails()
            {
                DisplayItems = displayItems,
                Total = totalItem,
                ShippingOptions = new List<PaymentShippingOption>
    {
        new PaymentShippingOption("Standard (3-5 business days)", new PaymentCurrencyAmount(0.00m, "USD")),
        new PaymentShippingOption( "Express (2-3 buiness days)", new PaymentCurrencyAmount(4.99m, "USD")),
        new PaymentShippingOption("Overnight (1 business day)", new PaymentCurrencyAmount(11.99m, "USD")),
    },
                Modifiers = new[]
            {
        new PaymentDetailsModifier(new []{"contoso/credit" },
        totalItemForContosoCard, displayItemsForContosoCard)
    },
            };

            // Describe options for any additional information needed to process the transaction.
            var options = new PaymentOptions()
            {
                RequestPayerName = PaymentOptionPresence.None,
                RequestPayerEmail = PaymentOptionPresence.None,
                RequestPayerPhoneNumber = PaymentOptionPresence.None,
                RequestShipping = true,
                ShippingType = PaymentShippingType.Shipping
            };

            var merchantInfo = new PaymentMerchantInfo(new Uri("https://store.contoso.com"));

            // Create a new payment request and associated internal state describing this proposed transaction.
            var request = new PaymentRequest(details, acceptedPaymentMethods, merchantInfo, options);

            // Submit the payment request for mediation and (possibly) user review and wait for the user to approve
            // or reject the request.
            var submissionResult = await paymentMediator.SubmitPaymentRequestAsync(request);

            if (submissionResult.Status != PaymentRequestStatus.Succeeded)
            {
                Console.WriteLine($"Payment request rejected by customer {submissionResult.Response}.");
                return;
            }

            //Your app waits for the user to tap Pay, then completes the order.
            await submissionResult.Response.CompleteAsync(PaymentRequestCompletionStatus.Succeeded);
        }
    }
}