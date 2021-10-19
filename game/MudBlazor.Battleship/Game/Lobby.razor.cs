using MudBlazor.Battleship.Hubs;
using MudBlazor.Battleship.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Game
{
    public partial class Lobby : ComponentBase
    {
        HubConnection connection;
        private User user = new User(string.Empty, string.Empty);
        private bool isSignedIn;
        private List<ChatMessage> _messages = new List<ChatMessage>();

        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public GameMode GameMode { get; set; }

        protected override async Task OnInitializedAsync()
        {
            connection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/gamehub")).Build();

            connection.On<ChatMessage>(nameof (IGameClient.RecieveMessage), NewChatMessage);

            await connection.StartAsync();
        }

        public async Task SignIn()
        {
            isSignedIn = true;
            await connection.InvokeAsync("JoinLobbyGroup", "lobby");
            await connection.InvokeAsync("SignIn", user.Name);
        }

        private void NewChatMessage(ChatMessage message)
        {
            _messages.Add(message);
            StateHasChanged();
        }

        public async Task LobbyMessage(string name, string message)
        {
            await connection.InvokeAsync("SendChat", name, message);
            StateHasChanged();
        }
    }
}
