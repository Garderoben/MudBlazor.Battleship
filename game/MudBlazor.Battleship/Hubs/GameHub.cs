using System;
using System.Text.Json;
using System.Threading.Tasks;
using MudBlazor.Battleship.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MudBlazor.Battleship.Enums;
using MudBlazor.Battleship.Services;

namespace MudBlazor.Battleship.Hubs
{
    public interface IGameClient
    {
        Task RecieveMessage(ChatMessage chatmessage);
        Task RecieveLobby(GameLobby lobby);
    }

    public class GameHub : Hub<IGameClient>
    {
        private readonly GameMode gamemode;

        public GameHub(GameMode gamemode)
        {
            this.gamemode = gamemode;
        }
        #region Groups
        public async Task JoinHubGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task LeaveHubGroup(string group)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }
        #endregion

        #region Connection
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            var user = gamemode.OnlineUsers().FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (user == null)
                return;

            await SendChat(user.Username, $"User {user.Username} has left the lobby");

            //await CleanupUserFromGames();
            //await CleanupUserFromUsersList();

            await base.OnDisconnectedAsync(exception);
        }
        #endregion
        public async Task SignIn(string name)
        {
            User user = new User(name, Context.ConnectionId);
            gamemode.OnlineUsers().Add(user);

            await SendChat(user.Username, $" has joined the lobby");
        }

        public async Task SendChat(string name, string message)
        {
            await Clients.Group("lobby").RecieveMessage(new ChatMessage(name, message));
        }

        public async Task SendNewLobby(GameLobby lobby)
        {
            gamemode.Lobbys().Add(lobby);
            await Clients.Group("lobby").RecieveLobby(lobby);
        }
    }
}
