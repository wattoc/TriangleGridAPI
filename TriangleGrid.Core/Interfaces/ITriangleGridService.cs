using TriangleGrid.Core.Models;

namespace TriangleGrid.Core.Interfaces
{
    public interface ITriangleGridService
    {
        public Triangle GetTriangleAtGridCoordinates(int gridSize, int triangleSideSize, GridCoordinate gridCoordinate);

        public GridCoordinate GetGridCoordinateForTriangle(int gridSize, int triangleSideSize, Triangle triangle);
    }
}
