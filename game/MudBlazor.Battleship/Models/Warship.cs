using MudBlazor.Battleship.Enums;
using System;

namespace MudBlazor.Battleship.Models
{
    public abstract class Warship
    {
        public Guid Id { get; set; }
        public Class Class { get; set; }
        public ShipStatus Status { get; set; }
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
            Id = Guid.NewGuid();
            Class = Class.AircraftCarrier;
            Size = 5;
        }
    }

    public class Cruiser : Warship
    {
        public Cruiser()
        {
            Id = Guid.NewGuid();
            Class = Class.Cruiser;
            Size = 4;
        }
    }
    public class Destroyer : Warship
    {
        public Destroyer()
        {
            Id = Guid.NewGuid();
            Class = Class.Destroyer;
            Size = 3;
        }
    }
    public class Submarine : Warship
    {
        public Submarine()
        {
            Id = Guid.NewGuid();
            Class = Class.Submarine;
            Size = 2;
        }
    }
}
