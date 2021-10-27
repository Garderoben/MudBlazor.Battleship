using System;

namespace MudBlazor.Battleship.Models
{
    public class GridSection
    {
        public Guid Id { get; set; }
        public Coordinates Coordinates { get; set; }
        public Warship Warship { get; set; }
        public GridSection(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
        }
        public bool IsOccupied
        {
            get
            {
                if(Warship != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
