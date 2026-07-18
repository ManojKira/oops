public class BankingCircleService
{
    public bool ProcessPayment(PaymentRequest request)
    {
        Console.WriteLine($"BankingCircle Processing {request.PaymentId}");

        return true;
    }
}