using MudBlazor.Battleship.Enums;

namespace MudBlazor.Battleship.Models
{
    public abstract class Ship
    {
        public Class Class { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public bool IsSunk
        {
            get
            {
                return Hits >= Size;
            }
        }
    }

    public class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            Class = Class.AircraftCarrier;
            Size = 5;
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Class = Class.Cruiser;
            Size = 4;
        }
    }
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Class = Class.Destroyer;
            Size = 3;
        }
    }
    public class Submarine : Ship
    {
        public Submarine()
        {
            Class = Class.Submarine;
            Size = 2;
        }
    }
}
