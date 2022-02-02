namespace ErrorHandlingExample.Services;

public interface ICounter
{
    Dictionary<string, int> UrlCounter { get; set; }
    void IncrementRequestPathCount(string requestPath);
}
