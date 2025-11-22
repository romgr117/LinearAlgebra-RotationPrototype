using RectangleRotationDemo.Models;
using ScottPlot;
using Rectangle = RectangleRotationDemo.Models.Rectangle;
using Color = ScottPlot.Color;

namespace RectangleRotationDemo.Visualization;

public static class PlotHelper
{
    public static void PlotRectangles(Rectangle original, Rectangle rotated, double angleDegrees)
    {
        Plot plot = new Plot();

        // Plot original rectangle
        AddRectangleToPlot(plot, original, Colors.Blue, "Original");

        // Plot rotated rectangle
        AddRectangleToPlot(plot, rotated, Colors.Red, "Rotated");

        // Configure plot
        plot.Title($"Rectangle Rotation ({angleDegrees}°)");
        plot.XLabel("X");
        plot.YLabel("Y");
        plot.ShowLegend();
        plot.Axes.SquareUnits();

        // Save to file and attempt to open
        string fileName = $"rectangle_rotation_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}.png";
        plot.SavePng(fileName, 800, 600);
        
        Console.WriteLine($"\nPlot saved to: {fileName}");
        
        // Try to open the image with default viewer
        TryOpenPlotFile(fileName);
    }

    private static void TryOpenPlotFile(string fileName)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = true
            });
            Console.WriteLine("Opening plot visualization...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not automatically open plot: {ex.Message}");
            Console.WriteLine($"Please open the file manually: {System.IO.Path.GetFullPath(fileName)}");
        }
    }

    private static void AddRectangleToPlot(Plot plot, Rectangle rectangle, Color color, string label)
    {
        IReadOnlyList<Point2D> vertices = rectangle.Vertices;
        
        double[] xCoords = vertices.Select(v => v.X).Append(vertices[0].X).ToArray();
        double[] yCoords = vertices.Select(v => v.Y).Append(vertices[0].Y).ToArray();

        ScottPlot.Plottables.Polygon poly = plot.Add.Polygon(xCoords, yCoords);
        poly.FillColor = color.WithAlpha(0.3);
        poly.LineColor = color;
        poly.LineWidth = 2;
        poly.LegendText = label;

        ScottPlot.Plottables.Scatter scatter = plot.Add.Scatter(xCoords, yCoords);
        scatter.MarkerSize = 8;
        scatter.MarkerFillColor = color;
        scatter.MarkerLineWidth = 0;
        scatter.LineWidth = 0;
    }
}
