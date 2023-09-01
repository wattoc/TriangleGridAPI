using TriangleGrid.Core.Models;

namespace TriangleGrid.Tests
{
    internal class TriangleTests
    {
        [Test]
        public void IsRightAngled_ShouldReturnFalseWhenNotRightAngled()
        {
            var triangle = new Triangle(new Point(30,0), new Point(10,50), new Point(40, 50));

            Assert.IsFalse(triangle.IsRightAngled());
        }

        [Test]
        public void IsRightAngled_ShouldReturnTrueWhenRightAngled()
        {
            var triangle = new Triangle(new Point(30, 0), new Point(30, 70), new Point(80, 70));

            Assert.IsTrue(triangle.IsRightAngled());
        }


        [Test]
        public void GetSides_ShouldReturnExpectedLengths()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(50,30), new Point(90,10));

            var sides = triangle.GetSides();

            Assert.That(sides.Any(side => Math.Round(side, 3) == 44.721));
            Assert.That(sides.Any(side => Math.Round(side, 3) == 90.554));
            Assert.That(sides.Any(side => Math.Round(side, 3) == 58.31));
        }

    }
}
