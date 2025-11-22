using RectangleRotationDemo.Common;

namespace RectangleRotationDemo.Helpers;

public static class ConsoleHelper
{
    public static Unit WaitForKeyPress()
    {
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
        return Unit.Value;
    }

    public static Unit HandleError(Exception error)
    {
        Console.Error.WriteLine($"Error: {error.Message}");
        Environment.Exit(1);
        return Unit.Value;
    }
}
