namespace Vesia.Template.Application.Common;

public enum ErrorType
{
    None,
    NotFound,
    Validation,
    Conflict,
    Unauthorized,
    Internal
}

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }
    public ErrorType ErrorType { get; }

    protected Result(bool isSuccess, string error, ErrorType errorType)
    {
        IsSuccess = isSuccess;
        Error = error;
        ErrorType = errorType;
    }

    public static Result Success() => new(true, string.Empty, ErrorType.None);
    public static Result Failure(string error, ErrorType errorType = ErrorType.Internal) => new(false, error, errorType);
}

public class Result<T> : Result
{
    public T Value { get; }

    private Result(T value) : base(true, string.Empty, ErrorType.None)
    {
        Value = value;
    }

    private Result(string error, ErrorType errorType) : base(false, error, errorType)
    {
        Value = default!;
    }

    public static Result<T> Success(T value) => new(value);
    public static new Result<T> Failure(string error, ErrorType errorType = ErrorType.Internal) => new(error, errorType);
}