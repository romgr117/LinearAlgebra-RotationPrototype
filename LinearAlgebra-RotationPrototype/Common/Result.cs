namespace RectangleRotationDemo.Common;

public readonly record struct Result<T>
{
    private readonly T? _value;
    private readonly Exception? _error;
    private readonly bool _isSuccess;

    private Result(T value, Exception? error, bool isSuccess)
    {
        _value = value;
        _error = error;
        _isSuccess = isSuccess;
    }

    public static Result<T> Success(T value) => new(value, null, true);
    public static Result<T> Failure(Exception error) => new(default, error, false);

    public Result<TOut> Bind<TOut>(Func<T, Result<TOut>> func) =>
        _isSuccess ? func(_value!) : Result<TOut>.Failure(_error!);

    public Result<TOut> Map<TOut>(Func<T, TOut> func) =>
        _isSuccess ? Result<TOut>.Success(func(_value!)) : Result<TOut>.Failure(_error!);

    public TOut Match<TOut>(Func<T, TOut> onSuccess, Func<Exception, TOut> onError) =>
        _isSuccess ? onSuccess(_value!) : onError(_error!);
}
