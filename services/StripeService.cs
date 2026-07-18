public class StripeService
{
    public bool ProcessPayment(PaymentRequest request)
    {
        Console.WriteLine($"Stripe Processing {request.PaymentId}");

        return true;
    }
}