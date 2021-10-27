using Microsoft.AspNetCore.Components;
using MudBlazor.Battleship.Components;
using MudBlazor.Battleship.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Game
{
    public partial class BattleshipGame
    {
        [CascadingParameter] public GameStateHub Game { get; set; }

        private List<string> DevLog = new List<string>();
        private BattleGrid BattleGrid = new();
        private Player PlayerOne = null;

        protected override async Task OnInitializedAsync()
        {
            if (!Game.isSignedIn)
            {
                NavMan.NavigateTo(NavMan.BaseUri);
            }
            else
            {
                PlayerOne = new Player(Game.CurrentUser);
            }
        }

        public void AddLogMessage(string message)
        {
            DevLog.Add(message);
            StateHasChanged();
        }
    }
}
