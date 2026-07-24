using System.Collections.Concurrent;
using System.Collections.Immutable;

public class CollectionsExample
{
    private readonly ConcurrentDictionary<string, string> payments = new();
    BlockingCollection<string> queue = new();
    
    public CollectionsExample()
    {
        // Call the method to demonstrate collections.
        // DemonstrateCollections();
    }

    public void DemonstrateCollections()
    {
        var processor = new CollectionsExample();

        Console.WriteLine("\nConcurrentDict example...............\n-------------------------------");
        Parallel.Invoke(
            () => processor.ConcurrentDict("PAY101"),
            () => processor.ConcurrentDict("PAY101"),
            () => processor.ConcurrentDict("PAY101")
        );

        ImmutableObjects();
        HashSetExample();
        SortedDictListExample();

        Task.Run(BlockingCollectionExample_Consumer);

        BlockingCollectionExample_Producer("PAY101");
        BlockingCollectionExample_Producer("PAY102");
        BlockingCollectionExample_Producer("PAY103");
    }

    public void ConcurrentDict(string paymentId)
    {
        if(!payments.TryAdd(paymentId, "Processing"))
        {
            Console.WriteLine($"Payment {paymentId} is already being processed.");
            return;
        }

        try
        {
            Console.WriteLine($"Processing PSP for payment {paymentId}...");
            // Simulate some processing time
            Thread.Sleep(1000);
            Console.WriteLine($"Payment {paymentId} completed at PSP.");
        }
        finally
        {
            payments.TryRemove(paymentId, out _);
        }
    }

    public void ImmutableObjects()
    {
        Console.WriteLine("\nImmutableObjects example...............\n-------------------------------");
        var psps = ImmutableList<string>.Empty;
        var list2 = psps.Add("Stripe");

        Console.WriteLine(psps.Count);
        Console.WriteLine(list2.Count);
    }

    public void HashSetExample()
    {
        Console.WriteLine("\nHashSetExample example...............\n-------------------------------");
        HashSet<string> currencies = new()
        {
            "USD",
            "EUR",
            "INR",
            "GBP",
            "AED"
        };

        if (!currencies.Contains("CNY"))
        {
            Console.WriteLine("Unsupported Currency");
        }
    }

    public void SortedDictListExample()
    {
        Console.WriteLine("\nSortedDictListExample example...............\n-------------------------------");
        SortedDictionary<string, string> sortedDict = new()
        {
            { "USD", "United States Dollar" },
            { "EUR", "Euro" },
            { "INR", "Indian Rupee" },
            { "GBP", "British Pound" },
            { "AED", "United Arab Emirates Dirham" }
        };

        foreach (var kvp in sortedDict)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

    public void BlockingCollectionExample_Producer(string paymentId)
    {
        Console.WriteLine($"Received {paymentId}");
        queue.Add(paymentId);
    }

    public void BlockingCollectionExample_Consumer()
    {
       while (true)
        {
            string payment = queue.Take();
            Console.WriteLine($"Processing {payment}");
            Thread.Sleep(1000);
            Console.WriteLine($"{payment} Completed");
        }
    }
}