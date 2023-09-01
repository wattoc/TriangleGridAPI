namespace TriangleGrid.Core.Models
{
    public abstract class Polygon
    {
        protected List<Point>? Vertices;

        /// <summary>
        /// Get Vertice at index
        /// </summary>
        /// <param name="index">zero based list index</param>
        /// <returns>Vertice</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Point GetVertice(uint index)
        {
            if (Vertices == null) throw new NullReferenceException("Polygon Vertices is null");
            if (index > Vertices.Count) throw new ArgumentOutOfRangeException(nameof(index));

            return Vertices[(int) index];
        }

        /// <summary>
        /// Test if shape has a Vertice at the supplied location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True when point found in Shape's vertices</returns>
        /// <exception cref="NullReferenceException"></exception>
        public bool HasVerticeAt(int x, int y)
        {
            if (Vertices == null) throw new NullReferenceException(nameof(Vertices));
            return Vertices.Any(vert => vert.X == x && vert.Y == y);
        }
    }
}
