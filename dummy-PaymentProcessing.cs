class PaymentProcessing
{
    public delegate void PaymentProcessedHandler(string message);

    public event PaymentProcessedHandler PaymentProcessed;

    public void ProcessPayment(decimal amount)
    {
        // Simulate payment processing logic
        // ...

        // Raise the event after processing the payment
        OnPaymentProcessed($"Payment of {amount:C} has been processed.");
    }

    protected virtual void OnPaymentProcessed(string message)
    {
        PaymentProcessed?.Invoke(message);
    }
}