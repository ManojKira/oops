public class PaymentExecutor
{
    public bool Execute(PaymentOperation operation,
                        PaymentRequest request)
    {
        Console.WriteLine("--------------------------------");

        Console.WriteLine("Logging Started");

        var start = DateTime.Now;

        bool result = operation(request);

        Console.WriteLine($"Execution Time : {DateTime.Now-start}");

        Console.WriteLine("Logging Completed");

        Console.WriteLine("--------------------------------");

        return result;
    }
}