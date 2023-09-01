using TriangleGrid.Core.Models;

namespace TriangleGrid.Tests
{
    internal class PolygonTests
    {
        private class PolygonMock: Polygon
        {
            public PolygonMock() { }

            public PolygonMock(List<Point> items)
            {
                Vertices = items;
            }
        }

        [Test]
        public void GetVertice_ThrowsExceptionWhenNone()
        {
            var polygon = new PolygonMock();

            Assert.Throws<NullReferenceException>(() => { polygon.GetVertice(0); });
        }

        [Test]
        public void GetVertice_ThrowsExceptionWhenVerticeIndexOutsideRange()
        {
            var polygon = new PolygonMock(new List<Point>(1));

            Assert.Throws<ArgumentOutOfRangeException>(() => { polygon.GetVertice(2); });
        }

        [Test]
        public void GetVertice_ReturnsExpectedItem()
        {
            var item0 = new Point(1, 2);
            var item1 = new Point(2, 3);

            var polygon = new PolygonMock(new List<Point> { item0, item1 });

            Assert.That(polygon.GetVertice(0).Equals(item0));
            Assert.That(polygon.GetVertice(1).Equals(item1));
        }

        [Test]
        public void HasVerticeAt_ReturnsTrueWhenMatched()
        {
            var item0 = new Point(1, 2);
            var item1 = new Point(2, 3);

            var polygon = new PolygonMock(new List<Point> { item0, item1 });

            Assert.IsTrue(polygon.HasVerticeAt(1,2));
        }

        [Test]
        public void HasVerticeAt_ReturnsFalseWhenNotMatched()
        {
            var item0 = new Point(1, 2);
            var item1 = new Point(2, 3);

            var polygon = new PolygonMock(new List<Point> { item0, item1 });

            Assert.IsFalse(polygon.HasVerticeAt(2, 1));
        }

    }
}
