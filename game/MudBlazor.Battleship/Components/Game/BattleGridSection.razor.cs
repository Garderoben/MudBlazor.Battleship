using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Battleship.Game;
using MudBlazor.Battleship.Models;

namespace MudBlazor.Battleship.Components
{
    public partial class BattleGridSection
    {
        [Parameter] public GridSection Section { get; set; }

        [CascadingParameter] public BattleshipGame Game { get; set; }

        private void OnSectionClick()
        {
            Game.AddLogMessage($"Section {Section.Coordinates.GetName()} clicked");
        }
    }
}
