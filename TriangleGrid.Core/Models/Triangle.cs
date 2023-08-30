namespace TriangleGrid.Core.Models
{
    public class Triangle : Polygon
    {
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            Vertices = new List<Point>
            {
                vertex1,
                vertex2,
                vertex3
            };
        }

        public override bool IsValid()
        {
            return Vertices != null && Vertices.Count == 3;
        }
    }
}