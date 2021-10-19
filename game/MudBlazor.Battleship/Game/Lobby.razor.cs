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
        private User user = new User();
        private bool isSignedIn;


        public List<ChatMessage> _messages = new();
        public List<GameLobby> _lobbys = new();

        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] private GameMode GameMode { get; set; }
        [Inject] private IGameData GameData { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }
        [Inject] private IDialogService Dialog { get; set; }

        MudTextField<string> ChatTextField;
        string NewMessage;

        protected override async Task OnInitializedAsync()
        {
            connection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/gamehub")).Build();
            connection.On<ChatMessage>(nameof (IGameClient.RecieveMessage), NewChatMessage);

            await connection.StartAsync();
        }

        public async Task SignIn()
        {
            var ExsistingUser = GameData.GetUser(user.Username);
            var NewUser = new User(user.Username, connection.ConnectionId);

            if (ExsistingUser == null)
            {
                try
                {
                    GameData.AddUser(NewUser);
                }
                catch
                {
                    Snackbar.Add("Failed to add new user", Severity.Error);
                    throw;
                }
            }

            user = NewUser;

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
            if (e.Code == "Enter")
            {
                _ = LobbyMessage(user.Username, NewMessage);
                ChatTextField.Clear();
                StateHasChanged();
            }
        }

        private async Task NewLobby()
        {
            var lobby = new GameLobby();
            var parameters = new DialogParameters { ["lobby"] = lobby };

            var dialog = Dialog.Show<NewLobby>("Create Lobby", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                lobby = (GameLobby)result.Data;
                _lobbys.Add(lobby);
            }
        }
    }
}
