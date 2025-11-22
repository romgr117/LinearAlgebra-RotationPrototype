using MathNet.Numerics.LinearAlgebra;

namespace RectangleRotationDemo.Helpers;

public static class MatrixFormattingHelper
{
    public static string FormatRotationMatrix(double angleDegrees, Matrix<double> rotationMatrix) =>
        $"\n\nRotation matrix R:\n{rotationMatrix.ToMatrixString()}";
}
