namespace LoggingExample.Services;

public interface ICounter
{
    Dictionary<int, int> NumberCounter { get; set; }
    void IncrementNumberCount(int requestPath);
}

