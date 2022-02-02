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
        if (UrlCounter.ContainsKey(requestPath))
        {
            UrlCounter[requestPath]++;
        }
        else
        {
            UrlCounter.Add(requestPath, 1);
        }
    }
}

