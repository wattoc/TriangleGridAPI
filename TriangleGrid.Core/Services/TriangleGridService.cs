using TriangleGrid.Core.Interfaces;
using TriangleGrid.Core.Models;

namespace TriangleGrid.Core.Services
{
    public class TriangleGridService : ITriangleGridService
    {
        /// <summary>
        /// Returns the Grid Coordinates for a supplied Triangle
        /// </summary>
        /// <param name="gridSize">Size of grid as squares</param>
        /// <param name="triangleSideSize">Size of the non-hypotenuse triangle side</param>
        /// <param name="triangle"></param>
        /// <returns>GridCoordinate</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public GridCoordinate GetGridCoordinateForTriangle(int gridSize, int triangleSideSize, Triangle triangle)
        {
            if (triangle == null) throw new ArgumentNullException("Triangle is null");
            if (gridSize < 1) throw new ArgumentOutOfRangeException(nameof(gridSize), "outside of allowed range");
            if (triangleSideSize < 1) throw new ArgumentOutOfRangeException(nameof(triangleSideSize), "outside of allowed range");
            
            var vertices = triangle.GetVertices();

            // check if any vertice is outside the grid
            if (vertices.Any(vertice =>
                vertice.X < 0 || vertice.X > ((gridSize * 2) * triangleSideSize) 
                || vertice.Y < 0 || vertice.Y > (gridSize * triangleSideSize))
                )
                throw new ArgumentOutOfRangeException(nameof(Triangle), "vertices are outside the grid");

            // check if triangle is right angled
            if (!triangle.IsRightAngled()) throw new ArgumentOutOfRangeException(nameof(Triangle), "not right angled");

            // check if any non hypotenuse side is not the allowed size
            if (triangle.GetSides().Where(side => side == triangleSideSize).Count() != 2) throw new ArgumentOutOfRangeException(nameof(Triangle), "sides length different to set size");

            int row = (Math.Min(Math.Min(vertices[0].Y, vertices[1].Y), vertices[2].Y) / triangleSideSize) + 1;
            int colEnd = Math.Max(Math.Max(vertices[0].X, vertices[1].X), vertices[2].X);
            int col = ((colEnd / triangleSideSize) * 2) - (vertices.Where(vertice => vertice.X == colEnd).Count() == 2 ? 0 : 1);

            return new GridCoordinate(row, col);
        }

        /// <summary>
        /// Return the Triangle for the supplied Grid Coordinate
        /// </summary>
        /// <param name="gridSize">Size of grid as squares</param>
        /// <param name="triangleSideSize">Size of the non-hypotenuse triangle side</param>
        /// <param name="gridCoordinate"></param>
        /// <returns>Triangle</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Triangle GetTriangleAtGridCoordinates(int gridSize, int triangleSideSize, GridCoordinate gridCoordinate)
        {
            if (gridCoordinate == null) throw new ArgumentNullException("GridCoordinate is null");
            if (gridSize < 1) throw new ArgumentOutOfRangeException(nameof(gridSize), "outside of allowed range");
            if (triangleSideSize < 1) throw new ArgumentOutOfRangeException(nameof(triangleSideSize), "outside of allowed range");

            int gridRow = gridCoordinate.RowAsInt();

            // check if any grid coordinate is outside the grid
            if (gridRow > gridSize || gridCoordinate.Column > (gridSize * 2)) throw new ArgumentOutOfRangeException(nameof(GridCoordinate), "coordinate values are outside the grid");
            int gridCol = (gridCoordinate.Column + 1) / 2;

            return new Triangle(
                new Point((gridCol - 1) * triangleSideSize, (gridRow - 1) * triangleSideSize),
                new Point(gridCol * triangleSideSize, gridRow * triangleSideSize),
                gridCoordinate.Column % 2 == 0
                ? new Point(gridCol * triangleSideSize, (gridRow - 1) * triangleSideSize)
                : new Point((gridCol - 1) * triangleSideSize, gridRow * triangleSideSize)
                );
        }
    }
}
