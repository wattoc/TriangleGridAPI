using System.Text.RegularExpressions;

namespace TriangleGrid.Core.Models
{
    public class GridCoordinate
    {
        public string Row { get; private set; }
        public int Column { get; private set; }

        /// <summary>
        /// Construct Grid Coordinate
        /// </summary>
        /// <param name="row">Base 26 row</param>
        /// <param name="column">Integer column</param>
        /// <exception cref="ArgumentException"></exception>
        public GridCoordinate(string row, int column)
        {
            if (!isValidRow(row) || column < 1) throw new ArgumentException("Supplied row or column invalid");
            Row = row.ToUpper();
            Column = column;
        }

        /// <summary>
        /// Construct Grid Coordinate
        /// </summary>
        /// <param name="row">Integer row</param>
        /// <param name="column">Integer column</param>
        /// <exception cref="ArgumentException"></exception>
        public GridCoordinate(int row, int column)
        {
            if (row < 1 || column < 1) throw new ArgumentException("Supplied row or column invalid");

            Row = toBase26(row);
            Column = column;
        }

        /// <summary>
        /// Convert Base 26 text row as an integer
        /// </summary>
        /// <returns>Value of Row as integer</returns>
        public int RowAsInt()
        {
            int numericRow = 0;
            var rowChars = Row.ToCharArray();

            for (int i = 0; i < rowChars.Length - 1; i++)
            {
                numericRow += (rowChars[i] - 64) * ((rowChars.Length - 1 - i) * 26);
            }
            numericRow += (rowChars[rowChars.Length - 1] - 64);

            return numericRow;
        }

        private static bool isValidRow(string row)
        {
            return Regex.IsMatch(row, @"^[a-zA-Z]+$");
        }

        private static string toBase26(int val)
        {
            var array = new LinkedList<char>();

            while (val > 26)
            {
                int curValue = val % 26;
                if (curValue != 0)
                {
                    val /= 26;
                    array.AddFirst((char)(curValue + 64));
                }
                else
                {
                    val = val / 26 - 1;
                    array.AddFirst('Z');
                }
            }

            if (val > 0)
            {
                array.AddFirst((char)(val + 64));
            }
            return new string(array.ToArray());
        }
    }
}
