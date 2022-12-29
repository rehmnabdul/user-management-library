namespace UserManagementLibrary;

public class Result<T>
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public Exception? Error { get; set; }

    public static Result<T> Success(string message, T data)
    {
        return new Result<T>
        {
            IsSuccessful = true,
            Message = message,
            Data = data,
            Error = null
        };
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>
        {
            IsSuccessful = false,
            Message = message,
            Data = default(T),
            Error = null
        };
    }

    public static Result<T> Failure(string message, Exception? error)
    {
        return new Result<T>
        {
            IsSuccessful = false,
            Message = message,
            Data = default(T),
            Error = error
        };
    }
}