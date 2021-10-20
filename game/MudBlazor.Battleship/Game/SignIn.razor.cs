using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using MudBlazor.Battleship.Models;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Game
{
    public partial class SignIn
    {
        [CascadingParameter] public GameStateHub Game { get; set; }

        private User user = new User();
        public async Task CheckUserDetails()
        {
            Game.CurrentUser = user;
            var ExsistingUser = Game.DbData.GetUser(user.Username);

            if (ExsistingUser == null)
            {
                try
                {
                    Game.DbData.AddUser(Game.CurrentUser);
                }
                catch
                {
                    Snackbar.Add("Failed to add new user", Severity.Error);
                    throw;
                }
            }
            Game.isSignedIn = true;

            await Game.Hub.InvokeAsync("JoinHubGroup", "lobby");
            NavMan.NavigateTo("game/lobby");
        }
    }
}
