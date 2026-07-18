public class EmailService
{
    public void SendReceipt(object sender,
                            PaymentCompletedEventArgs e)
    {
        Console.WriteLine(
            $"Email sent for Payment {e.PaymentId}\n\n");
    }
}