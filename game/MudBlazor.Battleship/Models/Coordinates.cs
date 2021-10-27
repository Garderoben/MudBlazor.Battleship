using MudBlazor.Battleship.Enums;
using MudBlazor.Extensions;

namespace MudBlazor.Battleship.Models
{
    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }

        Row RowLabel;
        Column ColumnLabel;

        public Coordinates(int row, int column)
        {
            Row = row;
            RowLabel = (Row)row;
            Column = column;
            ColumnLabel = (Column)column;
        }

        public string GetName()
        {
            return $"{RowLabel.ToDescriptionString()}:{ColumnLabel.ToDescriptionString()}";
        }
    }
}
