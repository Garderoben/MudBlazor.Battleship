using System;
using System.Text.Json;
using System.Threading.Tasks;
using MudBlazor.Battleship.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MudBlazor.Battleship.Enums;

namespace MudBlazor.Battleship.Hubs
{
    public interface IGameClient
    {
        Task RecieveMessage(ChatMessage chatmessage);
    }

    public class GameHub : Hub<IGameClient>
    {
        private readonly GameMode gamemode;

        public GameHub(GameMode gamemode)
        {
            this.gamemode = gamemode;
        }
        public async Task JoinLobbyGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task LeaveLobbyGroup(string group)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            var user = gamemode.GetUsers().FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (user == null)
                return;

            await SendChat(user.Name, $"User {user.Name} has left the lobby");

            //await CleanupUserFromGames();
            //await CleanupUserFromUsersList();

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SignIn(string name)
        {
            User user = new User(Context.ConnectionId, name);
            gamemode.GetUsers().Add(user);

            await SendChat(user.Name, $" has joined the lobby");
        }

        public async Task SendChat(string name, string message)
        {
            await Clients.Group("lobby").RecieveMessage(new ChatMessage(name, message));
        }
    }
}
