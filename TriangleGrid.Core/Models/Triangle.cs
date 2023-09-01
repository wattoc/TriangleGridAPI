namespace TriangleGrid.Core.Models
{
    public class Triangle : Polygon
    {
        private const int NUMBER_OF_VERTICES = 3;

        /// <summary>
        /// Create a Triangle from supplied vertices
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <param name="vertex3"></param>
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            Vertices = new List<Point>
            {
                vertex1,
                vertex2,
                vertex3
            };
        }

        /// <summary>
        /// Get Triangle Vertices
        /// </summary>
        /// <returns>List of Vertices</returns>
        public List<Point>? GetVertices()
        {
            return Vertices;
        }

        /// <summary>
        /// Calculate length of each Triangle side and return
        /// </summary>
        /// <returns>Array of side lengths</returns>
        public double[] GetSides()
        {
            double[] sides = new double[NUMBER_OF_VERTICES];

            int side_index = 0;

#pragma warning disable CS8602 // Dereference of a possibly null reference - not possible as prevented by constructor
            for (; side_index < (sides.Length - 1); side_index++)
            {
                sides[side_index] = Math.Sqrt(Math.Pow(Vertices[side_index].X - Vertices[side_index + 1].X, 2) + Math.Pow(Vertices[side_index].Y - Vertices[side_index + 1].Y, 2));
            }
            sides[side_index] = Math.Sqrt(Math.Pow(Vertices[side_index].X - Vertices[0].X, 2) + Math.Pow(Vertices[side_index].Y - Vertices[0].Y, 2));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return sides;
        }

        public bool IsRightAngled()
        {
            var sides = GetSides();
            
            // pythagoras theorem with some fudging given we use whole ints
            Array.Sort(sides);
            return (int)Math.Pow(sides[0], 2) + (int)Math.Pow(sides[1], 2) == (int)Math.Pow(sides[2], 2);
        }
    }
}