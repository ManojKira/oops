public class PaymentCompletedEventArgs : EventArgs
{
    public string? PaymentId { get; set; }

    public decimal Amount { get; set; }

    public string? TransactionId { get; set; }
}