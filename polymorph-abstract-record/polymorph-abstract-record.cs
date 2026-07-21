public class PolymorphAbstractRecord
{
    public void ExecutePolymorphAbstract()
    {
        PaymentGatewayService gateway;

        gateway = new StripePayment();
        gateway.PaymentProcess(3000);

        gateway = new PayPalPayment();
        gateway.PaymentProcess(1000);

        Console.WriteLine($"\nPolimorphism and Abstract Example:");
        ExecuteRecordExample();

        Console.WriteLine($"\nRequired Class Example:");
        var requiredClass = new RequiredClassExample
        {
            Name = "Required Name"
        };
        Console.WriteLine($"Required name value: {requiredClass.Name}");
    }

    public void ExecuteRecordExample()
    {
        var payment1 = new PaymentRequest2("PAY1001", 1000);
        var payment2 = new PaymentRequest2("PAY1001", 1000);

        Console.WriteLine($"\nRecord Example:");
        Console.WriteLine($"Payment1: {payment1}");
        Console.WriteLine($"Payment2: {payment2}");

        Console.WriteLine($"Are payment1 and payment2 equal? {payment1 == payment2}");
    }
}

public abstract class PaymentGatewayService
{
    public abstract void PaymentProcess(decimal amount);

    public void PaymentProcess(decimal amount, string currency)
    {
        Console.WriteLine($"Processing payment of {amount:C} in {currency} using PolymorphAbstractRecord.");
    }

    public void PaymentProcess(decimal amount, string currency, string paymentMethod)
    {
        Console.WriteLine($"Processing payment of {amount:C} in {currency} using {paymentMethod} via PolymorphAbstractRecord.");
    }
}

public class StripePayment : PaymentGatewayService
{
    public override void PaymentProcess(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} using Stripe.");
    }
}

public class PayPalPayment : PaymentGatewayService
{
    public override void PaymentProcess(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} using PayPal.");
    }
}

public record PaymentRequest2(
    string PaymentId,
    decimal Amount,
    string Currency = "USD");

public class RequiredClassExample
{
    public required string? Name { get; set; }
}