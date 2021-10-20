using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor.Battleship.Hubs;
using MudBlazor.Battleship.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Game
{
    public partial class SessionLobby
    {
        [CascadingParameter] public GameStateHub Game { get; set; }
        [Parameter] public Guid GameLobbyId { get; set; }

        public List<ChatMessage> _messages = new();

        protected override async Task OnInitializedAsync()
        {
            if (!Game.isSignedIn)
            {
                NavMan.NavigateTo(NavMan.BaseUri);
            }
            else
            {
                Game.Hub.On<ChatMessage>(nameof(IGameClient.RecieveMessage), RecieveChatMessage);
                await Game.Hub.InvokeAsync("SignIn", Game.CurrentUser.Username);
            }
        }

        private void RecieveChatMessage(ChatMessage message)
        {
            _messages.Add(message);
            StateHasChanged();
        }
    }
}
