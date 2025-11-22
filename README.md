# LinearAlgebra-RotationPrototype

A console application demonstrating 2D rectangle rotation using linear algebra transformations.

## Overview

This project creates an axis-aligned rectangle and rotates it by a specified angle using rotation matrices. It displays the original and rotated vertex coordinates, with optional rotation matrix visualization and interactive plotting.

## Dependencies

- **.NET 10.0 (Windows)**
- **MathNet.Numerics 5.0.0** - Used for matrix operations and linear algebra transformations
- **ScottPlot 5.1.57** - Industry-standard plotting library for visualizing the rotation

## Usage

Run the application with optional command-line arguments:

```bash
dotnet run [originX] [originY] [width] [height] [angleDegrees] [showMatrix] [showPlot]
```

**Example:**
```bash
dotnet run 0 0 5 3 45 true true
```

If no arguments are provided, default values are used.

### Parameters

- `originX`, `originY` - Starting coordinates of the rectangle
- `width`, `height` - Dimensions of the rectangle
- `angleDegrees` - Rotation angle in degrees
- `showMatrix` - Display the rotation matrix (true/false)
- `showPlot` - Generate and display a visual plot of the original and rotated rectangles (true/false)

## Project Structure

- `Models/` - Core data structures (`Rectangle`, `Point2D`)
- `Geometry/` - Rotation matrix and geometric transformations
- `Configuration/` - Command-line argument parsing
- `Visualization/` - Plotting utilities using ScottPlot
- `Program.cs` - Main entry point and application flow

## Features

- Functional programming patterns (Result monad, immutable records)
- 2D rotation transformations using matrix multiplication
- Visual plotting with ScottPlot (saves PNG and opens automatically)
- Interactive visualization showing both original (blue) and rotated (red) rectangles
- Command-line configuration with defaults
- Clean separation of concerns
