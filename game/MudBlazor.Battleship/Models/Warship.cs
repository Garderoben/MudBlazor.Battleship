using MudBlazor.Battleship.Enums;

namespace MudBlazor.Battleship.Models
{
    public abstract class Warship
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

    public class AircraftCarrier : Warship
    {
        public AircraftCarrier()
        {
            Class = Class.AircraftCarrier;
            Size = 5;
        }
    }

    public class Cruiser : Warship
    {
        public Cruiser()
        {
            Class = Class.Cruiser;
            Size = 4;
        }
    }
    public class Destroyer : Warship
    {
        public Destroyer()
        {
            Class = Class.Destroyer;
            Size = 3;
        }
    }
    public class Submarine : Warship
    {
        public Submarine()
        {
            Class = Class.Submarine;
            Size = 2;
        }
    }
}
