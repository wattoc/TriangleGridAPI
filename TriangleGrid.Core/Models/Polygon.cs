namespace TriangleGrid.Core.Models
{
    public abstract class Polygon
    {
        protected List<Point>? Vertices;

        public abstract bool IsValid();

        public Point GetVertice(uint index)
        {
            if (Vertices == null) throw new ArgumentNullException(nameof(Vertices));
            if (index > Vertices.Count) throw new ArgumentOutOfRangeException(nameof(index));

            return Vertices[(int) index];
        }

        public bool HasVerticeAt(int x, int y)
        {
            if (Vertices == null) throw new ArgumentNullException(nameof(Vertices));
            return Vertices.Any(vert => vert.X == x && vert.Y == y);
        }
    }
}
