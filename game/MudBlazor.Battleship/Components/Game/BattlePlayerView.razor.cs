using Microsoft.AspNetCore.Components;
using MudBlazor.Battleship.Game;
using MudBlazor.Battleship.Models;
using System;
using System.Collections.Generic;
using MudBlazor.Battleship.Components;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Components
{
    public partial class BattlePlayerView
    {
        [CascadingParameter] public GameStateHub Game { get; set; }

        private List<string> DevLog = new List<string>();
        private BattleGrid BattleGrid = new();
        private Player PlayerOne = null;
        public void AddLogMessage(string message)
        {
            DevLog.Add(message);
            StateHasChanged();
        }
    }
}
