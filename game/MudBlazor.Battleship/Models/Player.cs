using System.Collections.Generic;
using System.Linq;

namespace MudBlazor.Battleship.Models
{
    public class Player
    {
        public User User { get; set; }
        public List<Warship> Warships { get; set; }
        public bool HasLost
        {
            get
            {
                return Warships.All(x => x.IsSunk);
            }
        }

        public Player(User user)
        {
            User = user;
            Warships = new List<Warship>()
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
