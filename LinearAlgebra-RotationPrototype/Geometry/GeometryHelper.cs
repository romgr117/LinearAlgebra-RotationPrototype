using MathNet.Numerics.LinearAlgebra;
using RectangleRotationDemo.Models;

namespace RectangleRotationDemo.Geometry;

public static class GeometryHelper
{
    public static Matrix<double> CreateRotationMatrix(double angleDegrees)
    {
        double angleRadians = DegreesToRadians(angleDegrees);

        double cos = Math.Cos(angleRadians);
        double sin = Math.Sin(angleRadians);

        return Matrix<double>.Build.DenseOfArray(new[,]
        {
            {  cos, -sin },
            {  sin,  cos }
        });
    }

    public static Point2D RotatePoint(Point2D point, Matrix<double> rotationMatrix)
    {
        if (rotationMatrix.RowCount != 2 || rotationMatrix.ColumnCount != 2)
        {
            throw new ArgumentException("Rotation matrix must be 2x2.", nameof(rotationMatrix));
        }

        Vector<double> vector = Vector<double>.Build.DenseOfArray(new[] { point.X, point.Y });
        Vector<double> rotated = rotationMatrix * vector;

        return new Point2D(rotated[0], rotated[1]);
    }

    private static double DegreesToRadians(double degrees) => degrees * Math.PI / 180.0;
}
