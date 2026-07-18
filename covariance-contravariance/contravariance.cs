public class ContravarianceExample
{
    //Example
    //CardPaymeent -> PAssed to validator
    //In behaviour
    public void contravarianceExmple()
    {
        IPaymentValidator<PayRequest> validator = new PaymentValidator();
        IPaymentValidator<CardPayment> cardPaymentValidator = validator; //Contravariance
        CardPayment cardPayment = new CardPayment { PaymentId = "102", CardNumber = "1111-2222-3333-4444" };
        cardPaymentValidator.ValidatePayment(cardPayment);
    }
}

public interface IPaymentValidator<in T>
{
    void ValidatePayment(T payment);
}

public class PaymentValidator : IPaymentValidator<PayRequest>
{
    public void ValidatePayment(PayRequest payment)
    {
        Console.WriteLine($"\nContravariance Example:\nValidating {payment.PaymentId}");
    }
}