using System.Threading.Tasks;
using MudBlazor.Battleship.Models;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using MudBlazor.Battleship.Services;
using MudBlazor.Extensions;
using MudBlazor.Battleship.Enums;

namespace MudBlazor.Battleship.Hubs
{
    public interface IGameClient
    {
        Task RecieveMessage(ChatMessage chat);
        Task RecieveLobby(GameLobby lobby);
        Task UpdateLobby(GameLobby lobby);
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

            await base.OnDisconnectedAsync(exception);
        }
        #endregion
        public async Task SignIn(User user)
        {
            gamemode.OnlineUsers().Add(user);
            await Clients.Group(user.ChatGroup).RecieveMessage(new ChatMessage(user, $"{user.Username} has joined the lobby"));
        }

        public async Task SendChat(ChatMessage chat)
        {
            await Clients.Group(chat.User.ChatGroup).RecieveMessage(chat);
        }

        public async Task SendNewLobby(GameLobby lobby)
        {
            gamemode.Lobbys().Add(lobby);
            await Clients.Group(GroupType.Global.ToDescriptionString()).RecieveLobby(lobby);
        }

        public async Task SendUpdateLobby(GameLobby selected, User user)
        {
            var lobby = gamemode.Lobbys().Where(l => l.Id == selected.Id).First();
            lobby.Players.Add(user);
            await Clients.Group(GroupType.Global.ToDescriptionString()).RecieveLobby(lobby);
        }
    }
}
