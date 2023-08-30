namespace TriangleGrid.Core.Models
{
    public class GridCoordinate
    {
        public string Row { get; set; }
        public int Column { get; set; }

        public GridCoordinate(string row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
