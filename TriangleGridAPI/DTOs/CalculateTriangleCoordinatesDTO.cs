using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TriangleGrid.WebAPI.DTOs
{
    public class CalculateTriangleCoordinatesDTO
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        [DefaultValue("A")]
        public string Row { get; set; }

        [Required]
        [Range(1, int.MaxValue / 2)]
        [DefaultValue("1")]
        public int Column { get; set; }

        [Required]
        public GridSizeDTO GridSize { get; set; }

    }
}
