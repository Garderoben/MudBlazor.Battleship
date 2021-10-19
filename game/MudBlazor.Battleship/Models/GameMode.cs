using System.Collections.Generic;

namespace MudBlazor.Battleship.Models
{
    public interface GameMode
    {
        List<User> GetUsers();
        List<GameLobby> GetLobbys();
    }

    public class InMemoryGamemode : GameMode
    {
        private List<User> GameUsers = new List<User>();
        private List<GameLobby> GameLobbys = new List<GameLobby>();
        
        public List<User> GetUsers()
        {
            return GameUsers;
        }

        public List<GameLobby> GetLobbys()
        {
            return GameLobbys;
        }
    }
}
