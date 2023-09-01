using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TriangleGrid.Core.Models;

namespace TriangleGrid.WebAPI.DTOs
{
    public class TriangleDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public List<PointDTO>? Coordinates { get; set; }

        public TriangleDTO() { }

        internal TriangleDTO(Triangle triangle)
        {
            Coordinates = triangle.GetVertices().Select(vertice => new PointDTO(vertice)).ToList();
        }

        internal Triangle AsTriangle()
        {
            if (Coordinates == null || Coordinates.Count != 3) throw new ArgumentNullException(nameof(Coordinates));

            return new Triangle(Coordinates[0].AsPoint(), Coordinates[1].AsPoint(), Coordinates[2].AsPoint());
        }

    }

    public class PointDTO
    {
        [Required]
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int X { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int Y { get; set; }

        public PointDTO() { }

        internal PointDTO(Point point)
        {
            X = point.X; Y = point.Y;
        }

        internal Point AsPoint()
        {
            return new Point(X, Y);
        }
    }
}
