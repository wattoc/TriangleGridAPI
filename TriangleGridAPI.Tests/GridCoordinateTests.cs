using TriangleGrid.Core.Models;

namespace TriangleGrid.Tests
{
    internal class GridCoordinateTests
    {
        [Test]
        [TestCase("{}", 1)]
        [TestCase("A", -1)]
        [TestCase("2-25", -1)]
        public void Constructor_ThrowsExceptionForInvalidRowOrColumn(string row, int col)
        {
            Assert.Throws<ArgumentException>(() => new GridCoordinate(row, col));
        }

        [Test]
        [TestCase("A", 1)]
        [TestCase("D", 4)]
        [TestCase("AA", 27)]
        [TestCase("AB", 28)]
        [TestCase("AC", 29)]
        [TestCase("AZ", 52)]
        public void Constructor_MapsIntegerRowToExpectedString(string expected, int row) 
        {
            Assert.That(new GridCoordinate(row, 1).Row == expected);
        }

        [Test]
        [TestCase("A", 1)]
        [TestCase("D", 4)]
        [TestCase("AA", 27)]
        [TestCase("AB", 28)]
        [TestCase("AC", 29)]
        [TestCase("AZ", 52)]
        public void RowToInt_MapsToExpectedInteger(string row, int expected)
        {
            Assert.That(new GridCoordinate(row, 1).RowAsInt() == expected);
        }

    }
}
