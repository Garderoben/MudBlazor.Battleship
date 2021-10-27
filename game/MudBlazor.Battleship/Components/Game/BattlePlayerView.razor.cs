using Microsoft.AspNetCore.Components;
using MudBlazor.Battleship.Game;
using MudBlazor.Battleship.Models;
using System;
using System.Collections.Generic;
using MudBlazor.Battleship.Components;
using System.Threading.Tasks;
using MudBlazor.Battleship.Enums;
using System.Linq;

namespace MudBlazor.Battleship.Components
{
    public partial class BattlePlayerView
    {
        [CascadingParameter] public GameStateHub Game { get; set; }
        [Parameter] public EventCallback<Warship> OnGridUpdated { get; set; }

        private List<string> DevLog = new List<string>();
        private BattleGrid BattleGrid = new();
        public Player Player = null;

        public Warship Payload { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!Game.isSignedIn)
            {
                NavMan.NavigateTo(NavMan.BaseUri);
            }
            else
            {
                Player = new Player(Game.CurrentUser);
            }
        }

        public void AddLogMessage(string message)
        {
            DevLog.Add(message);
            StateHasChanged();
        }

        public async Task UpdateGridAsync(ShipStatus status)
        {
            var task = Player.Warships.SingleOrDefault(x => x.Id == Payload.Id);

            if (task != null)
            {
                task.Status = status;
                await OnGridUpdated.InvokeAsync(Payload);
                StateHasChanged();
            }
        }

    }
}
