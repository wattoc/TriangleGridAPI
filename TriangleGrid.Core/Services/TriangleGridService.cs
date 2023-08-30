using TriangleGrid.Core.Interfaces;
using TriangleGrid.Core.Models;

namespace TriangleGrid.Core.Services
{
    public class TriangleGridService : ITriangleGridService
    {
        private uint _size;
        private uint _triangle_side_size;

        /// <summary>
        /// Instantiate a new triangle grid, based on right angle triangles, aligned in half squares horizontally
        /// Grid rows are represented with letters starting from A, columns numbers starting from 1
        /// </summary>
        /// <param name="size">Size represents number of rows, since a triangle is half a square there are twice as many columns as rows</param>
        /// <param name="triangle_side_size">The size of the non-hypoteneuse sides</param>
        public TriangleGridService(uint size, uint triangle_side_size) 
        {
            _size = size;
            _triangle_side_size = triangle_side_size;
        }

        public GridCoordinate GetGridCoordinateForTriangle(Triangle triangle)
        {
            throw new NotImplementedException();
        }

        public Triangle GetTriangleAtGridCoordinates(GridCoordinate gridCoordinate)
        {
            throw new NotImplementedException();
        }
    }
}
