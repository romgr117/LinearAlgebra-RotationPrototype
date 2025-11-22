using RectangleRotationDemo.Common;
using RectangleRotationDemo.Configuration;
using RectangleRotationDemo.Geometry;
using RectangleRotationDemo.Helpers;
using RectangleRotationDemo.Visualization;
using Rectangle = RectangleRotationDemo.Models.Rectangle;

namespace RectangleRotationDemo;

internal static class Program
{
    private static void Main(string[] args) =>
        RunProgram(args)
            .Match(
                onSuccess: _ => ConsoleHelper.WaitForKeyPress(),
                onError: error => ConsoleHelper.HandleError(error));

    private static Result<Unit> RunProgram(string[] args) =>
        FunctionalHelper.Try(() => RotationConfig.ParseArgumentsOrUseDefaults(args))
            .Bind(config => ExecuteRotationDemo(config))
            .Map(_ => Unit.Value);

    private static Result<Unit> ExecuteRotationDemo(RotationConfig config) =>
        FunctionalHelper.Try(() =>
        {
            string output = BuildOutput(config);
            Console.WriteLine(output);
            return Unit.Value;
        });

    private static string BuildOutput(RotationConfig config)
    {
        Rectangle rectangle = Rectangle.CreateAxisAligned(
            config.OriginX,
            config.OriginY,
            config.Width,
            config.Height);

        string originalVertices = rectangle.FormatVertices("Original rectangle vertices:");
        string rotationInfo = $"\nRotation angle: {config.RotationAngleDegrees}°";
        string matrixInfo = config.ShowRotationMatrix
            ? FormatRotationMatrix(config.RotationAngleDegrees)
            : "";
        Rectangle rotatedRectangle = rectangle.Rotate(config.RotationAngleDegrees);
        string rotatedVertices = rotatedRectangle.FormatVertices("\nRotated rectangle vertices:");

        if (config.ShowPlot)
        {
            PlotHelper.PlotRectangles(rectangle, rotatedRectangle, config.RotationAngleDegrees);
        }

        return $"{originalVertices}{rotationInfo}{matrixInfo}\n{rotatedVertices}";
    }

    private static string FormatRotationMatrix(double angleDegrees)
    {
        MathNet.Numerics.LinearAlgebra.Matrix<double> rotationMatrix = GeometryHelper.CreateRotationMatrix(angleDegrees);
        return MatrixFormattingHelper.FormatRotationMatrix(angleDegrees, rotationMatrix);
    }
}
