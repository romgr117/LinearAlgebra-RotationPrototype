using RectangleRotationDemo.Common;
using RectangleRotationDemo.Geometry;

namespace RectangleRotationDemo.Models;

public sealed record Rectangle
{
    public IReadOnlyList<Point2D> Vertices { get; }

    public Rectangle(IEnumerable<Point2D> vertices)
    {
        Vertices = (vertices ?? throw new ArgumentNullException(nameof(vertices))).ToList().AsReadOnly();

        if (Vertices.Count != 4)
        {
            throw new ArgumentException("A rectangle must have exactly 4 vertices.", nameof(vertices));
        }
    }

    public static Rectangle CreateAxisAligned(double originX, double originY, double width, double height) =>
        Validate(width, height)
            .Bind(() => new Rectangle(new[]
            {
                new Point2D(originX, originY),
                new Point2D(originX + width, originY),
                new Point2D(originX + width, originY + height),
                new Point2D(originX, originY + height)
            }));

    public Rectangle Rotate(double angleDegrees) =>
        new(Vertices
            .Select(vertex => GeometryHelper.RotatePoint(
                vertex,
                GeometryHelper.CreateRotationMatrix(angleDegrees))));

    public string FormatVertices(string? label = null) =>
        (string.IsNullOrEmpty(label) ? "" : $"{label}\n") +
        string.Join("\n", Vertices.Select((v, i) => $"Vertex {i + 1}: {v}"));

    private static Result<Unit> Validate(double width, double height) =>
        width <= 0 ? throw new ArgumentException("Width must be positive.", nameof(width))
        : height <= 0 ? throw new ArgumentException("Height must be positive.", nameof(height))
        : new Result<Unit>(Unit.Value);

    private readonly record struct Result<T>(T Value)
    {
        public Rectangle Bind(Func<Rectangle> func) => func();
    }
}
