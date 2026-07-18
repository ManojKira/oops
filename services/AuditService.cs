public class AuditService
{
    public void SaveAudit(object sender,
                          PaymentCompletedEventArgs e)
    {
        Console.WriteLine(
            $"Audit saved for {e.TransactionId}\n\n");
    }
}