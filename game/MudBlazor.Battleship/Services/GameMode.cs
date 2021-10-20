using MudBlazor.Battleship.Models;
using System.Collections.Generic;

namespace MudBlazor.Battleship.Services
{
    public interface GameMode
    {
        List<User> OnlineUsers();
        List<GameLobby> Lobbys();
    }

    public class InMemoryGamemode : GameMode
    {
        private List<User> GameUsers = new List<User>();
        private List<GameLobby> GameLobbys = new List<GameLobby>();
        
        public List<User> OnlineUsers()
        {
            return GameUsers;
        }

        public List<GameLobby> Lobbys()
        {
            return GameLobbys;
        }
    }
}
