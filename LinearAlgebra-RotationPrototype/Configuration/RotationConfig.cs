namespace RectangleRotationDemo.Configuration;

public sealed record RotationConfig
{
    public required double OriginX { get; init; }
    public required double OriginY { get; init; }
    public required double Width { get; init; }
    public required double Height { get; init; }
    public required double RotationAngleDegrees { get; init; }
    public required bool ShowRotationMatrix { get; init; }
    public required bool ShowPlot { get; init; }

    public static RotationConfig CreateDefault() =>
        new()
        {
            OriginX = 0,
            OriginY = 0,
            Width = 4,
            Height = 4,
            RotationAngleDegrees = 90.0,
            ShowRotationMatrix = true,
            ShowPlot = true
        };

    public static RotationConfig ParseArgumentsOrUseDefaults(string[] args) =>
        args.Length > 0
            ? CreateDefaultWithWarning()
            : CreateDefault();

    private static RotationConfig CreateDefaultWithWarning()
    {
        Console.WriteLine("Command-line arguments detected but not yet implemented.");
        Console.WriteLine("Using default configuration.\n");
        return CreateDefault();
    }
}
