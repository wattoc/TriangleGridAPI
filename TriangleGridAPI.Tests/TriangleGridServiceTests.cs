using TriangleGrid.Core.Services;
using TriangleGrid.Core.Interfaces;
using TriangleGrid.Core.Models;

namespace TriangleGridAPI.Tests
{
    public class TriangleGridServiceTests
    {
        private ITriangleGridService Service;

        [SetUp]
        public void Setup()
        {
            Service = new TriangleGridService(6, 10);
        }

        [Test]
        public void GridTopLeft_ShouldReturnTopLeftTriangle()
        {
            var triangle = Service.GetTriangleAtGridCoordinates(new GridCoordinate("A", 1));

            Assert.IsNotNull(triangle);
            Assert.That(triangle.HasVerticeAt(0, 0));
            Assert.That(triangle.HasVerticeAt(0, 10));
            Assert.That(triangle.HasVerticeAt(10, 10));
        }

        [Test]
        public void GridBottomRight_ShouldReturnBottomRightTriangle()
        {
            var triangle = Service.GetTriangleAtGridCoordinates(new GridCoordinate("F", 12));

            Assert.IsNotNull(triangle);
            Assert.That(triangle.HasVerticeAt(50, 50));
            Assert.That(triangle.HasVerticeAt(60, 50));
            Assert.That(triangle.HasVerticeAt(60, 60));
        }

        [Test]
        public void GridC4_ShouldReturnTriangleC4Vertices()
        {
            var triangle = Service.GetTriangleAtGridCoordinates(new GridCoordinate("C", 4));

            Assert.IsNotNull(triangle);
            Assert.That(triangle.HasVerticeAt(10, 20));
            Assert.That(triangle.HasVerticeAt(20, 20));
            Assert.That(triangle.HasVerticeAt(20, 30));
        }

        [Test]
        public void TriangleTopLeft_ShouldReturnGridTopLeft()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 10));

            var gridLoc = Service.GetGridCoordinateForTriangle(triangle);

            Assert.IsNotNull(gridLoc);
            Assert.That(gridLoc.Column == 1);
            Assert.That(gridLoc.Row == "A");
        }

        [Test]
        public void TriangleBottomRight_ShouldReturnGridBottomRight()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 10));

            var gridLoc = Service.GetGridCoordinateForTriangle(triangle);

            Assert.IsNotNull(gridLoc);
            Assert.That(gridLoc.Column == 12);
            Assert.That(gridLoc.Row == "F");
        }

        [Test]
        public void TriangleC4Vertices_ShouldReturnGridC4()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 10));

            var gridLoc = Service.GetGridCoordinateForTriangle(triangle);

            Assert.IsNotNull(gridLoc);
            Assert.That(gridLoc.Column == 4);
            Assert.That(gridLoc.Row == "C");
        }


        [Test]
        public void OutsideTriangle_ShouldThrowException()
        {
            var triangle = new Triangle(new Point(100, 200), new Point(200, 200), new Point(200, 300));

            Assert.Throws<ArgumentException>(() => Service.GetGridCoordinateForTriangle(triangle));
        }

        [Test]
        public void GridOutside_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => Service.GetTriangleAtGridCoordinates(new GridCoordinate("Z", 99)));
        }

    }
}