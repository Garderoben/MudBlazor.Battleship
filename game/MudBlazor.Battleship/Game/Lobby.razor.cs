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
using System.Linq;
using MudBlazor.Battleship.Enums;

namespace MudBlazor.Battleship.Game
{
    public partial class Lobby
    {
        [CascadingParameter] public GameStateHub Game { get; set; }

        GameLobby NewGameLobby;
        GameLobby SelectedGameLobby;

        private bool isAddNewLobby;
        private bool isValidNewLobby;


        public List<ChatMessage> _messages = new();
        public List<GameLobby> _lobbys = new();

        protected override async Task OnInitializedAsync()
        {
            if (!Game.isSignedIn)
            {
                NavMan.NavigateTo(NavMan.BaseUri);
            }
            else
            {
                _lobbys = Game.Mode.Lobbys().ToList();

                Game.Hub.On<GameLobby>(nameof(IGameClient.RecieveLobby), RecieveGameLobby);
                Game.Hub.On<ChatMessage>(nameof(IGameClient.RecieveMessage), RecieveChatMessage);
                
                await Game.Hub.InvokeAsync("SignIn", Game.CurrentUser);
            }
        }

        #region Chat
        private void RecieveChatMessage(ChatMessage chat)
        {
            _messages.Add(chat);
            StateHasChanged();
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
            await CreateNewLobby(NewGameLobby.Id);
        }

        private async Task CreateNewLobby(Guid Id)
        {
            await Game.LeaveChatGroup(GroupType.Global);
            await Game.JoinChatGroup(GroupType.Lobby, Id);

            NavMan.NavigateTo($"/game/lobby/{Id}");
        }
        #endregion

        private async Task JoinLobby()
        {
            if (SelectedGameLobby != null && SelectedGameLobby.Players.Count <= 2 )
            {
                SelectedGameLobby.Players.Add(Game.CurrentUser);

                await Game.LeaveChatGroup(GroupType.Global);
                await Game.JoinChatGroup(GroupType.Lobby, SelectedGameLobby.Id);

                await Game.Hub.InvokeAsync("SendUpdateLobby", SelectedGameLobby, Game.CurrentUser);

                NavMan.NavigateTo($"/game/lobby/{SelectedGameLobby.Id}");
            }
        }
    }
}
