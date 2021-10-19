using MudBlazor.Battleship.Hubs;
using MudBlazor.Battleship.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace MudBlazor.Battleship.Game
{
    public partial class Lobby : ComponentBase
    {
        HubConnection connection;
        private User user = null;
        private SignInForm SignInForm = new SignInForm();
        private bool isSignedIn;


        private List<ChatMessage> _messages = new List<ChatMessage>();
        private List<GameLobby> _lobbys = new List<GameLobby>();

        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public GameMode GameMode { get; set; }

        private MudTextField<string> ChatTextField;
        private ChatMessage Message { get; set; }

        protected override async Task OnInitializedAsync()
        {
            connection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/gamehub")).Build();

            connection.On<ChatMessage>(nameof (IGameClient.RecieveMessage), NewChatMessage);

            await connection.StartAsync();
        }

        public async Task SignIn()
        {
            isSignedIn = true;
            user = new User(connection.ConnectionId, SignInForm.Username);
            Message = new ChatMessage(user.Name, null);

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

        private void OnKeyUp(KeyboardEventArgs e)
        {
            string newMessage = Message.Message;

            if (e.Code == "Enter")
            {
                _ = LobbyMessage(user.Name, newMessage);
                ChatTextField.Clear();
                StateHasChanged();
            }
        }
    }
}
