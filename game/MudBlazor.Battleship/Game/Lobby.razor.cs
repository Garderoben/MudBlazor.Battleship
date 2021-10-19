using MudBlazor.Battleship.Hubs;
using MudBlazor.Battleship.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using System;
using MudBlazor.Battleship.Data;

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
        [Inject] private GameMode GameMode { get; set; }
        [Inject] private IGameData GameData { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }

        private MudTextField<string> ChatTextField;
        private ChatMessage Message;

        protected override async Task OnInitializedAsync()
        {
            connection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/gamehub")).Build();

            connection.On<ChatMessage>(nameof (IGameClient.RecieveMessage), NewChatMessage);

            await connection.StartAsync();
        }

        public async Task SignIn()
        {
            var ExsistingUser = await GameData.GetUser(SignInForm.Username);
            var NewUser = new User(SignInForm.Username, connection.ConnectionId);

            if (ExsistingUser == null)
            {
                try
                {
                    await GameData.AddUser(NewUser);
                }
                catch
                {
                    Snackbar.Add("Failed to add new user", Severity.Error);
                    throw;
                }
            }

            isSignedIn = true;

            await connection.InvokeAsync("JoinLobbyGroup", "lobby");
            await connection.InvokeAsync("SignIn", user.Username);
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
                _ = LobbyMessage(user.Username, newMessage);
                ChatTextField.Clear();
                StateHasChanged();
            }
        }
    }
}
