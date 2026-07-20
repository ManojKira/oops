using System.Collections;

public class linqExample
{
    public List<LinqPayment> payments = new List<LinqPayment>();
    
    public linqExample()
    {
    }
    public void LinqExampleExecute()
    {
        var payments = new List<LinqPayment>
        {
            new LinqCardPayment
            {
                PaymentId="P1",
                MerchantId="M1",
                PSP="Stripe",
                Amount=500,
                Currency="INR",
                Status="Success",
                Rules = new()
                {
                    new FraudRule{RuleName="Velocity"},
                    new FraudRule{RuleName="IP Check"}
                }
            },

            new LinqCardPayment
            {
                PaymentId="P2",
                MerchantId="M1",
                PSP="Razorpay",
                Amount=1200,
                Currency="INR",
                Status="Failed",
                Rules = new()
                {
                    new FraudRule{RuleName="Card BIN"}
                }
            },

            new LinqCardPayment
            {
                PaymentId="P3",
                MerchantId="M2",
                PSP="Stripe",
                Amount=2500,
                Currency="USD",
                Status="Success",
                IsRefunded=true,
                Rules = new()
                {
                    new FraudRule{RuleName="Geo Check"}
                }
            },

            new LinqCardPayment
            {
                PaymentId="P4",
                MerchantId="M2",
                PSP="Adyen",
                Amount=800,
                Currency="INR",
                Status="Pending"
            },

            new LinqCardPayment
            {
                PaymentId="P5",
                MerchantId="M3",
                PSP="Stripe",
                Amount=7000,
                Currency="USD",
                Status="Success"
            }
        };

        var merchants = new List<Merchant>
        {
            new(){MerchantId="M1",Name="Amazon"},
            new(){MerchantId="M2",Name="Flipkart"},
            new(){MerchantId="M3",Name="Myntra"}
        };

        RunAllLinqExamples(payments, merchants);
    }

    static void RunAllLinqExamples(List<LinqPayment> payments, List<Merchant> merchants)
    {
        Console.WriteLine("\n========== WHERE ==========");
        payments.Where(x => x.Status == "Success")
                .ToList()
                .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== SELECT ==========");
        payments.Select(x => new { x.PaymentId, x.Amount })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.PaymentId} {x.Amount}"));

        Console.WriteLine("\n========== SELECT MANY ==========");
        payments.SelectMany(x => x.Rules)
                .ToList()
                .ForEach(x => Console.WriteLine(x.RuleName));

        Console.WriteLine("\n========== ORDER BY ==========");
        payments.OrderBy(x => x.Amount)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.PaymentId} {x.Amount}"));

        Console.WriteLine("\n========== ORDER BY DESC ==========");
        payments.OrderByDescending(x => x.Amount)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.PaymentId} {x.Amount}"));

        Console.WriteLine("\n========== THEN BY ==========");
        payments.OrderBy(x => x.Status)
                .ThenByDescending(x => x.Amount)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Status} {x.PaymentId} {x.Amount}"));

        Console.WriteLine("\n========== GROUP BY ==========");
        foreach (var grp in payments.GroupBy(x => x.PSP))
        {
            Console.WriteLine(grp.Key);

            foreach (var p in grp)
                Console.WriteLine($"   {p.PaymentId}");
        }

        Console.WriteLine("\n========== JOIN ==========");
        payments.Join(merchants,
                p => p.MerchantId,
                m => m.MerchantId,
                (p, m) => new
                {
                    p.PaymentId,
                    Merchant = m.Name
                })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.PaymentId} {x.Merchant}"));

        Console.WriteLine("\n========== COUNT ==========");
        Console.WriteLine(payments.Count(x => x.Status == "Success"));

        Console.WriteLine("\n========== SUM ==========");
        Console.WriteLine(payments.Sum(x => x.Amount));

        Console.WriteLine("\n========== AVERAGE ==========");
        Console.WriteLine(payments.Average(x => x.Amount));

        Console.WriteLine("\n========== MIN ==========");
        Console.WriteLine(payments.Min(x => x.Amount));

        Console.WriteLine("\n========== MAX ==========");
        Console.WriteLine(payments.Max(x => x.Amount));

        Console.WriteLine("\n========== FIRST OR DEFAULT ==========");
        var firstFailed = payments.FirstOrDefault(x => x.Status == "Failed");
        Console.WriteLine(firstFailed?.PaymentId);

        Console.WriteLine("\n========== SINGLE OR DEFAULT ==========");
        var payment = payments.SingleOrDefault(x => x.PaymentId == "P3");
        Console.WriteLine(payment?.PaymentId);

        Console.WriteLine("\n========== ANY ==========");
        Console.WriteLine(payments.Any(x => x.Status == "Failed"));

        Console.WriteLine("\n========== ALL ==========");
        Console.WriteLine(payments.All(x => x.Status == "Success"));

        Console.WriteLine("\n========== DISTINCT ==========");
        payments.Select(x => x.PSP)
                .Distinct()
                .ToList()
                .ForEach(Console.WriteLine);

        Console.WriteLine("\n========== TAKE ==========");
        payments.Take(2)
                .ToList()
                .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== SKIP ==========");
        payments.Skip(2)
                .ToList()
                .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== CONTAINS ==========");
        string[] supported = { "Stripe", "Adyen" };

        payments.Where(x => supported.Contains(x.PSP))
                .ToList()
                .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== TO DICTIONARY ==========");
        var dictionary = payments.ToDictionary(x => x.PaymentId);

        Console.WriteLine(dictionary["P2"].PSP);

        Console.WriteLine("\n========== TO LOOKUP ==========");
        var lookup = payments.ToLookup(x => x.PSP);

        foreach (var p in lookup["Stripe"])
            Console.WriteLine(p.PaymentId);

        Console.WriteLine("\n========== UNION ==========");
        var list1 = new[] { "P1", "P2", "P3" };
        var list2 = new[] { "P3", "P4", "P5" };

        list1.Union(list2)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("\n========== CONCAT ==========");
        list1.Concat(list2)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("\n========== INTERSECT ==========");
        list1.Intersect(list2)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("\n========== EXCEPT ==========");
        list1.Except(list2)
            .ToList()
            .ForEach(Console.WriteLine);

        Console.WriteLine("\n========== OFTYPE ==========");

        ArrayList array = new();

        array.Add(new CardPayment { PaymentId = "CP1" });
        array.Add("Hello");
        array.Add(10);
        array.Add(new CardPayment { PaymentId = "CP2" });

        array.OfType<CardPayment>()
            .ToList()
            .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== CAST ==========");

        ArrayList paymentArray = new();

        paymentArray.Add(new LinqPayment { PaymentId = "PX1" });
        paymentArray.Add(new LinqPayment { PaymentId = "PX2" });

        paymentArray.Cast<LinqPayment>()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== AGGREGATE ==========");
        Console.WriteLine(
            payments.Aggregate(0m,
                (total, payment) => total + payment.Amount));

        Console.WriteLine("\n========== DEFAULT IF EMPTY ==========");

        payments.Where(x => x.Status == "Cancelled")
                .DefaultIfEmpty(new LinqPayment
                {
                    PaymentId = "No Cancelled Payments"
                })
                .ToList()
                .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== REVERSE ==========");

        payments.Reverse<LinqPayment>()
                .ToList()
                .ForEach(x => Console.WriteLine(x.PaymentId));

        Console.WriteLine("\n========== SEQUENCE EQUAL ==========");

        var batch1 = new[] { "P1", "P2", "P3" };
        var batch2 = new[] { "P1", "P2", "P3" };

        Console.WriteLine(batch1.SequenceEqual(batch2));

        CustomLinqExample(payments);
    }

    public static void CustomLinqExample(IEnumerable<LinqPayment> payments)
    {
        var successfulPayments = payments.Successful();
        Console.WriteLine("\n========== CUSTOM LINQ EXTENSION ==========");
        successfulPayments.ToList()
            .ForEach(x => Console.WriteLine(x.PaymentId));
    }
}

public static class PaymentExtensions
{
    public static IEnumerable<LinqPayment> Successful(
        this IEnumerable<LinqPayment> payments)
    {
        return payments.Where(p => p.Status == "Success");
    }
}

public class LinqPayment
{
    public string? PaymentId { get; set; }
    public string? MerchantId { get; set; }
    public string? PSP { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }
    public string? Status { get; set; }
    public bool IsRefunded { get; set; }

    public List<FraudRule> Rules { get; set; } = new();
}

public class FraudRule
{
    public string? RuleName { get; set; }
}

public class Merchant
{
    public string MerchantId { get; set; }
    public string Name { get; set; }
}

public class LinqCardPayment : LinqPayment
{
}
