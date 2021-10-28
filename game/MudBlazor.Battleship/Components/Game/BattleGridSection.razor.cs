using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Battleship.Enums;
using MudBlazor.Battleship.Game;
using MudBlazor.Battleship.Models;
using MudBlazor.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MudBlazor.Battleship.Components
{
    public partial class BattleGridSection : IDisposable
    {
        [CascadingParameter] BattlePlayerView DropContainer { get; set; }
        [CascadingParameter] public BattlePlayerView Game { get; set; }

        [Parameter] public GridSection Section { get; set; }

        private bool _init;

        protected override void OnParametersSet()
        {
            if (_init == false && DropContainer != null)
            {
                DropContainer.OnShipmentPlacementRequested += OnShipmentPlacementRequested;
                _init = true;
            }

            base.OnParametersSet();
        }

        private void OnShipmentPlacementRequested(object sender, ShipmentPlacementRequestedInfo info)
        {
            if (info.Coordinates.Row == Section.Coordinates.Row && info.Coordinates.Column == Section.Coordinates.Column)
            {
                PlaceShip(info.Ship);
            }
        }

        protected string GridClass =>
        new CssBuilder("grid-item flex-column mud-ripple")
        .Build();

        protected string DropClass =>
        new CssBuilder("warship-dropzone battle")
          .AddClass($"dropzone-can-drop", DropShip)
          .AddClass($"dropzone-no-drop", !DropShip)
        .Build();

        private bool DropShip;
        private bool disposedValue;

        private void HandleDragEnter() => DropShip = true;
        //{
        //    DropShip =  DropContainer.IsDropPossible(Ship, Section.Coordinates);

        //}

        private void HandleDragLeave() => DropShip = false;

        private async Task HandleDrop()
        {
            DropShip = false;
            var ship = DropContainer.Payload;
            var rotation = Rotation.Horizontal;
            Section.Warship = ship;

            List<Coordinates> affectedSections = new();
            if (rotation == Rotation.Horizontal)
            {
                for (int i = 1; i < ship.Size; i++)
                {
                    affectedSections.Add(new Coordinates(Section.Coordinates.Row, Section.Coordinates.Column + i));
                }
            }
            else
            {
                for (int i = 1; i < ship.Size; i++)
                {
                    affectedSections.Add(new Coordinates(Section.Coordinates.Row + i, Section.Coordinates.Column));
                }
            }

            //inform other affected Sections
            DropContainer.SetShipToSections(ship, affectedSections);

            await DropContainer.UpdateGridAsync(ShipStatus.Deployed);
        }

        private void PlaceShip(Warship ship) => Section.Warship = ship;


        private void OnSectionClick()
        {
            Game.AddLogMessage($"Section {Section.Coordinates.GetName()} clicked");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DropContainer.OnShipmentPlacementRequested -= OnShipmentPlacementRequested;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
