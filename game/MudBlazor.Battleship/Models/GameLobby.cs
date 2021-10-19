namespace MudBlazor.Battleship.Models
{
    public class GameLobby
    {
        public string Name { get; set; }
        public string Players { get; set; }
        public string Password { get; set; }

        public GameLobby(string name, string players, string password)
        {
            Name = name;
            Players = players;
            Password = password;
        }
    }
}
