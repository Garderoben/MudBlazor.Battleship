using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using MudBlazor.Battleship.Models;
using MudBlazor.Battleship.Enums;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Game
{
    public partial class SignIn
    {
        [CascadingParameter] public GameStateHub Game { get; set; }

        private User user = new User();
        public async Task OnSignInClick()
        {
            Game.CurrentUser = user;
            Game.DbData.AddUser(Game.CurrentUser);
            Game.isSignedIn = true;

            await Game.JoinChatGroup(GroupType.Global);
            NavMan.NavigateTo("game/lobby");
        }

        public async Task OnSignInDevClick()
        {
            user.Username = "Garderoben";
            Game.CurrentUser = user;
            Game.DbData.AddUser(Game.CurrentUser);
            Game.isSignedIn = true;

            await Game.JoinChatGroup(GroupType.Global);
            NavMan.NavigateTo("game/battle");
        }
    }
}
