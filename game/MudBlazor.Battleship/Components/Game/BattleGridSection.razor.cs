using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Battleship.Enums;
using MudBlazor.Battleship.Game;
using MudBlazor.Battleship.Models;
using MudBlazor.Utilities;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Components
{
    public partial class BattleGridSection
    {
        [CascadingParameter] BattlePlayerView DropContainer { get; set; }
        [CascadingParameter] public BattlePlayerView Game { get; set; }

        [Parameter] public GridSection Section { get; set; }

        protected string GridClass =>
        new CssBuilder("grid-item flex-column mud-ripple")
        .Build();

        protected string DropClass =>
        new CssBuilder("warship-dropzone battle")
          .AddClass($"can-drop", DropShip)
          .AddClass($"no-drop", !DropShip)
        .Build();

        private bool DropShip;

        private void HandleDragEnter() => DropShip = true;
        private void HandleDragLeave() => DropShip = false;

        private async Task HandleDrop()
        {
            DropShip = false;
            Section.Warship = DropContainer.Payload;
            await DropContainer.UpdateGridAsync(ShipStatus.Deployed);
        }

        private void OnSectionClick()
        {
            Game.AddLogMessage($"Section {Section.Coordinates.GetName()} clicked");
        }
    }
}
