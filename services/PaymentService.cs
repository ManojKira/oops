public class PaymentService
{
    // Event declaration
    public event EventHandler<PaymentCompletedEventArgs> PaymentCompleted;

    public PaymentResult ProcessPayment(PaymentRequest request)
    {
        Console.WriteLine("\n\nProcessing payment...");

        // Assume PSP call succeeded

        var result = new PaymentResult
        {
            Success = true,
            TransactionId = Guid.NewGuid().ToString()
        };

        Console.WriteLine("Payment Successful");

        // Raise event
        OnPaymentCompleted(new PaymentCompletedEventArgs
        {
            PaymentId = request.PaymentId,
            Amount = request.Amount,
            TransactionId = result.TransactionId
        });

        return result;
    }

    protected virtual void OnPaymentCompleted(PaymentCompletedEventArgs args)
    {
        PaymentCompleted?.Invoke(this, args);
    }
}