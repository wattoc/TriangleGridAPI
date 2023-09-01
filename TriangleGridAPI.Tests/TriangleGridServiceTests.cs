using TriangleGrid.Core.Services;
using TriangleGrid.Core.Interfaces;
using TriangleGrid.Core.Models;

namespace TriangleGridAPI.Tests
{
    public class TriangleGridServiceTests
    {
        private ITriangleGridService _service;
        private const int GRID_SIZE = 6;
        private const int TRIANGLE_SIZE_SIZE = 10;

        [SetUp]
        public void Setup()
        {
            _service = new TriangleGridService();
        }

        [Test]
        public void GridTopLeft_ShouldReturnTopLeftTriangle()
        {
            var triangle = _service.GetTriangleAtGridCoordinates(GRID_SIZE, TRIANGLE_SIZE_SIZE, new GridCoordinate("A", 1));

            Assert.IsNotNull(triangle);
            Assert.That(triangle.HasVerticeAt(0, 0));
            Assert.That(triangle.HasVerticeAt(0, 10));
            Assert.That(triangle.HasVerticeAt(10, 10));
        }

        [Test]
        public void GridBottomRight_ShouldReturnBottomRightTriangle()
        {
            var triangle = _service.GetTriangleAtGridCoordinates(GRID_SIZE, TRIANGLE_SIZE_SIZE, new GridCoordinate("F", 12));

            Assert.IsNotNull(triangle);
            Assert.That(triangle.HasVerticeAt(50, 50));
            Assert.That(triangle.HasVerticeAt(60, 50));
            Assert.That(triangle.HasVerticeAt(60, 60));
        }

        [Test]
        public void GridC4_ShouldReturnTriangleC4Vertices()
        {
            var triangle = _service.GetTriangleAtGridCoordinates(GRID_SIZE, TRIANGLE_SIZE_SIZE, new GridCoordinate("C", 4));

            Assert.IsNotNull(triangle);
            Assert.That(triangle.HasVerticeAt(10, 20));
            Assert.That(triangle.HasVerticeAt(20, 20));
            Assert.That(triangle.HasVerticeAt(20, 30));
        }

        [Test]
        public void TriangleTopLeft_ShouldReturnGridTopLeft()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 10));

            var gridLoc = _service.GetGridCoordinateForTriangle(GRID_SIZE, TRIANGLE_SIZE_SIZE, triangle);

            Assert.IsNotNull(gridLoc);
            Assert.That(gridLoc.Column == 1);
            Assert.That(gridLoc.Row == "A");
        }

        [Test]
        public void TriangleBottomRight_ShouldReturnGridBottomRight()
        {
            var triangle = new Triangle(new Point(50, 50), new Point(60, 50), new Point(60, 60));

            var gridLoc = _service.GetGridCoordinateForTriangle(GRID_SIZE, TRIANGLE_SIZE_SIZE, triangle);

            Assert.IsNotNull(gridLoc);
            Assert.That(gridLoc.Column == 12);
            Assert.That(gridLoc.Row == "F");
        }

        [Test]
        public void TriangleC4Vertices_ShouldReturnGridC4()
        {
            var triangle = new Triangle(new Point(10, 20), new Point(20, 20), new Point(20, 30));

            var gridLoc = _service.GetGridCoordinateForTriangle(GRID_SIZE, TRIANGLE_SIZE_SIZE, triangle);

            Assert.IsNotNull(gridLoc);
            Assert.That(gridLoc.Column == 4);
            Assert.That(gridLoc.Row == "C");
        }


        [Test]
        public void OutsideTriangle_ShouldThrowException()
        {
            var triangle = new Triangle(new Point(100, 200), new Point(200, 200), new Point(200, 300));

            Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetGridCoordinateForTriangle(GRID_SIZE, TRIANGLE_SIZE_SIZE, triangle));
        }

        [Test]
        public void GridOutside_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetTriangleAtGridCoordinates(GRID_SIZE, TRIANGLE_SIZE_SIZE, new GridCoordinate("Z", 99)));
        }

    }
}