using System;

namespace MudBlazor.Battleship.Models
{
    public class GridSection
    {
        public Guid Id { get; set; }
        public Coordinates Coordinates { get; set; }
        public Ship Ship { get; set; }
        public GridSection(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
        }
        public bool IsOccupied
        {
            get
            {
                if(Ship != null)
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
