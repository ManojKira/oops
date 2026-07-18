public class MerchantNotificationService
{
    public void NotifyMerchant(object sender,
                               PaymentCompletedEventArgs e)
    {
        Console.WriteLine(
            $"Merchant {e.TransactionId} notified\n\n");
    }
}