//1. Delegate example
//===================================================================
// var stripe = new StripeService();

// var banking = new BankingCircleService();

// var executor = new PaymentExecutor();

// var payment = new PaymentRequest
// {
//     PaymentId="PAY1001",
//     Amount=1000
// };

// executor.Execute(stripe.ProcessPayment, payment);
// executor.Execute(banking.ProcessPayment, payment);
//===================================================================

//2. Events example
//===================================================================
var paymentService = new PaymentService();

var email = new EmailService();

var audit = new AuditService();

var merchant = new MerchantNotificationService();

//subscribe to events
paymentService.PaymentCompleted += email.SendReceipt!;
paymentService.PaymentCompleted += audit.SaveAudit!;
paymentService.PaymentCompleted += merchant.NotifyMerchant!;

var request = new PaymentRequest
{
    PaymentId = "PAY1001",

    Amount = 5000
};

paymentService.ProcessPayment(request);
//===================================================================

//3. Covariance and Contravariance example
CovarianceExample covariance = new CovarianceExample();
ContravarianceExample contravariance = new ContravarianceExample();
covariance.covarianceExmple();
contravariance.contravarianceExmple();
//===================================================================

