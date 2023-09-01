using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TriangleGrid.WebAPI.DTOs
{
    public class GridSizeDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        [DefaultValue("6")]
        public int Size { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [DefaultValue("10")]
        public int TriangleSideSize { get; set; }
    }
}
