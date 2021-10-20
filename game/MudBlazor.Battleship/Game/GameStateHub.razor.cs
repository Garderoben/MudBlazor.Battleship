using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor.Battleship.Data;
using MudBlazor.Battleship.Models;
using MudBlazor.Battleship.Services;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Game
{
    public partial class GameStateHub
    {
        [Inject] public IGameDbData DbData { get; set; }
        [Inject] public GameMode Mode { get; set; }

        public HubConnection Hub;
        public User CurrentUser;
        public bool isSignedIn;

        protected override async Task OnInitializedAsync()
        {
            Hub = new HubConnectionBuilder().WithUrl(NavMan.ToAbsoluteUri("/gamehub")).Build();
            await Hub.StartAsync();
        }
    }
}
