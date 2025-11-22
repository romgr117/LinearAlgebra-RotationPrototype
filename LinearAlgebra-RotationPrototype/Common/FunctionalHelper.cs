namespace RectangleRotationDemo.Common;

public static class FunctionalHelper
{
    public static Result<T> Try<T>(Func<T> func)
    {
        try
        {
            return Result<T>.Success(func());
        }
        catch (Exception ex)
        {
            return Result<T>.Failure(ex);
        }
    }
}
