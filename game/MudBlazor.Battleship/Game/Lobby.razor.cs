using MudBlazor.Battleship.Hubs;
using MudBlazor.Battleship.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using System;
using MudBlazor.Battleship.Data;
using MudBlazor.Battleship.Services;

namespace MudBlazor.Battleship.Game
{
    public partial class Lobby
    {
        [CascadingParameter] public GameStateHub Game { get; set; }

        string NewMessage;
        GameLobby NewGameLobby;

        private bool isAddNewLobby;
        private bool isValidNewLobby;


        public List<ChatMessage> _messages = new();
        public List<GameLobby> _lobbys = new();

        MudTextField<string> ChatTextField;

        protected override async Task OnInitializedAsync()
        {
            if (!Game.isSignedIn)
            {
                NavMan.NavigateTo(NavMan.BaseUri);
            }
            else
            {
                _lobbys = Game.Mode.Lobbys();

                Game.Hub.On<ChatMessage>(nameof(IGameClient.RecieveMessage), RecieveChatMessage);
                await Game.Hub.InvokeAsync("SignIn", Game.CurrentUser.Username);
            }
        }


        #region Chat
        private void RecieveChatMessage(ChatMessage message)
        {
            _messages.Add(message);
            StateHasChanged();
        }

        public async Task SendChat(string name, string message)
        {
            await Game.Hub.InvokeAsync("SendChat", name, message);
            StateHasChanged();
        }

        private void OnKeyUp(KeyboardEventArgs e)
        {
            if (e.Code == "Enter")
            {
                _ = SendChat(Game.CurrentUser.Username, NewMessage);
                ChatTextField.Clear();
                StateHasChanged();
            }
        }
        #endregion

        #region Lobby
        private void RecieveGameLobby(GameLobby lobby)
        {
            _lobbys.Add(lobby);
            StateHasChanged();
        }
        private void OnButtonClickNewLobby()
        {
            NewGameLobby = new GameLobby()
            {
                Id = Guid.NewGuid(),
                Players = new List<User>()
            };

            isAddNewLobby = true;
        }

        private async Task SendNewLobby()
        {
            NewGameLobby.Players.Add(Game.CurrentUser);

            await Game.Hub.InvokeAsync("SendNewLobby", NewGameLobby);
            await JoinLobby(NewGameLobby.Id.ToString());
        }

        private async Task JoinLobby(string lobbyId)
        {
            await Game.Hub.InvokeAsync("LeaveHubGroup", "lobby");
            await Game.Hub.InvokeAsync("JoinHubGroup", $"lobby-{lobbyId}");

            NavMan.NavigateTo($"/game/lobby/{lobbyId}");
        }
        #endregion
    }
}
