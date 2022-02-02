namespace ErrorHandlingExample.Services;

public class Counter : ICounter
{
    public Dictionary<string, int> UrlCounter { get; set; }

    public Counter()
    {
        UrlCounter = new Dictionary<string, int>();
    }

    public void IncrementRequestPathCount(string requestPath)
    {
        UrlCounter[requestPath]++;
    }
}

