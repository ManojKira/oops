public class CovarianceExample
{
    //Example
    //PaymentRequest -> CardPayment / UpiPayment / NetBankingPayment
    //Out behaviour
    public void covarianceExmple()
    {
        IPaymentFactory<CardPayment> cardPaymentFactory = new CardPaymentFactory();
        IPaymentFactory<PayRequest> factory = cardPaymentFactory; //Covariance        
        PayRequest payment = factory.ProcessPayment();
        Console.WriteLine("\nCovariance Example:\nCard Payment Id Out: " + payment.PaymentId);
        IPaymentFactory<UpiPayment> upiPaymentFactory = new UpiPaymentFactory();
        IPaymentFactory<PayRequest> factory2 = upiPaymentFactory; //Covariance
        PayRequest payment2 = factory2.ProcessPayment();
        Console.WriteLine("\nUpi Payment Id Out: " + payment2.PaymentId);
    }

    //Example
    //CardPaymeent -> PAssed to validator
    //In behaviour
    public void contravarianceExmple()
    {
        
    }
}

//Base and derived classes
public class PayRequest
{
    public string? PaymentId { get; set; }
}

public class CardPayment : PayRequest
{
    public string? CardNumber { get; set; }
}

public class UpiPayment : PayRequest
{
    public string? UpiId { get; set; }
}

//IPaymentFactory interface with covariance
public interface IPaymentFactory<out T>
{
    T ProcessPayment();
}

public class CardPaymentFactory : IPaymentFactory<CardPayment>
{
    public CardPayment ProcessPayment()
    {
        return new CardPayment { PaymentId = "102", CardNumber = "1111-2222-3333-4444" };
    }
}

public class UpiPaymentFactory : IPaymentFactory<UpiPayment>
{
    public UpiPayment ProcessPayment()
    {
        return new UpiPayment { PaymentId = "103", UpiId = "user@upi" };
    }
}