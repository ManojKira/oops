public class AsyncAwaitExample
{
    public AsyncAwaitExample()
    {
        // Call the asynchronous method and wait for its completion.
        ProcessPaymentAsync().GetAwaiter().GetResult();
    }
    public async Task ProcessPaymentAsync()
    {
        Console.WriteLine("Async and Await Example");
        Console.WriteLine("Validation");
        var result = await CallStripeApiAsync();
        Console.WriteLine(result);
        Console.WriteLine("Saving Payment");
    }
    // This method simulates an asynchronous call to the Stripe API.
    public async Task<string> CallStripeApiAsync()
    {
        Console.WriteLine("Calling Stripe...");
        await Task.Delay(3000);
        Console.WriteLine("Stripe Replied");
        return "SUCCESS";
    }
}