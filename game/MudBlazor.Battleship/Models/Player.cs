using System.Collections.Generic;
using System.Linq;

namespace MudBlazor.Battleship.Models
{
    public class Player
    {
        public User User { get; set; }
        public List<Ship> Ships { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Player(User user)
        {
            User = user;
            Ships = new List<Ship>()
            {
                new AircraftCarrier(),
                new Cruiser(),
                new Cruiser(),
                new Destroyer(),
                new Destroyer(),
                new Destroyer(),
                new Submarine(),
                new Submarine(),
                new Submarine(),
                new Submarine(),
            };
        }
    }
}
