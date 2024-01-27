using System.Text.Json.Serialization;

namespace MovieApi.Services.Models;

public class Attempt<T> : Attempt
{
    public T? Result { get; }

    private Attempt()
    {
    }
    
    private Attempt(T result)
    {
        Success = true;
        Result = result;
    }

    public static Attempt<T> Succeed(T result)
    {
        return new Attempt<T>(result);
    }

    public new static Attempt<T> Fail(string message)
    {
        var attempt = new Attempt<T>
        {
            Success = false,
            ErrorMessage = message
        };

        return attempt;
    }
}

public class Attempt
{
    [JsonIgnore]
    public Exception? Error { get; }
    public string? ErrorMessage { get; protected init; }
    public bool Success { get; protected init; }

    internal Attempt()
    {
    }

    private Attempt(Exception error)
    {
        Success = false;
        Error = error;
        ErrorMessage = error.Message;
    }
    
    public static Attempt Fail(string errorMessage)
    {
        return new Attempt(new Exception(errorMessage));
    }
    
    public static Attempt Fail(Exception exception)
    {
        return new Attempt(exception);
    }

    public static Attempt Succeed()
    {
        var attempt = new Attempt
        {
            Success = true
        };

        return attempt;
    }
}