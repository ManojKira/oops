public class PatternMatchingExample
{
    public void DemonstratePatternMatching()
    {
        PaymentMethod payment1 = new CardPayment1 { Method = "Card", CardNumber = "1234-5678-9012-3456" };
        PaymentMethod payment2 = new UpiPayment1 { Method = "UPI", UpiId = "user@upi" };
        
        TypePatternMatching(payment1);
        TypePatternMatching(payment2);

        var request1 = new PaymentRequest1(1000, "INR", "India");
        PropertyPatternMatching(request1);

        SwitchExpressionPatternMatching(payment1);
    }

    public void TypePatternMatching(PaymentMethod payment)
    {
        Console.WriteLine("\nType Pattern Matching Example:");
        if (payment is CardPayment1 card)
        {
            Console.WriteLine($"Processing card payment with card number: {card.CardNumber}");
        }
        else if (payment is UpiPayment1 upi)
        {
            Console.WriteLine($"Processing UPI payment with UPI ID: {upi.UpiId}");
        }
        else
        {
            Console.WriteLine("Unknown payment method.");
        }
    }

    public void PropertyPatternMatching(PaymentRequest1 request)
    {
        Console.WriteLine("\nProperty Pattern Matching Example:");
        if (request is { Currency: "INR" })
        {
            Console.WriteLine("Indian Payment");
        }
    }

    public void SwitchExpressionPatternMatching(PaymentMethod payment)
    {
        Console.WriteLine("\nSwitch Expression Pattern Matching Example:");
        int fee = payment.Method switch
        {
            "UPI" => 2,
            "Card" => 5,
            "Wallet" => 3,
            _ => 0
        };

        Console.WriteLine($"Processing payment with fee: {fee}");
    }
}

public record PaymentRequest1(
    decimal Amount,
    string Currency,
    string Country);

public abstract class PaymentMethod
{
    public string? Method { get; init; }
}

public class CardPayment1 : PaymentMethod
{
    public string? CardNumber { get; init; }
}

public class UpiPayment1 : PaymentMethod
{
    public string? UpiId { get; init; }
}