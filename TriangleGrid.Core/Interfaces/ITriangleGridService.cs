using TriangleGrid.Core.Models;

namespace TriangleGrid.Core.Interfaces
{
    public interface ITriangleGridService
    {
        public Triangle GetTriangleAtGridCoordinates(GridCoordinate gridCoordinate);

        public GridCoordinate GetGridCoordinateForTriangle(Triangle triangle);
    }
}
