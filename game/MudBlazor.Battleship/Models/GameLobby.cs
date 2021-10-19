using System.ComponentModel.DataAnnotations;

namespace MudBlazor.Battleship.Models
{
    public class GameLobby
    {
        [Required]
        [StringLength(12, ErrorMessage = "Lobby name can't be more than 12 characters.", MinimumLength = 4)]
        public string Name { get; set; }
        public string Players { get; set; }

        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }

        public GameLobby() { }
        public GameLobby(string name, string players, string password)
        {
            Name = name;
            Players = players;
            Password = password;
        }
    }
}
