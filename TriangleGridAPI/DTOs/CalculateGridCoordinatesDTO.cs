using System.ComponentModel.DataAnnotations;
using TriangleGrid.Core.Models;

namespace TriangleGrid.WebAPI.DTOs
{
    public class CalculateGridCoordinatesDTO
    {
        [Required]
        public TriangleDTO Triangle { get; set; }

        [Required]
        public GridSizeDTO GridSize { get; set; }
    }
}
