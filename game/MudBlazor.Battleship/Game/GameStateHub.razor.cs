using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor.Battleship.Data;
using MudBlazor.Battleship.Enums;
using MudBlazor.Battleship.Models;
using MudBlazor.Battleship.Services;
using MudBlazor.Extensions;
using System;
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

        public async Task JoinChatGroup(GroupType group, Guid id = default(Guid))
        {
            CurrentUser.ChatGroup = GetChatGroupName(group, id);
            await Hub.InvokeAsync("JoinHubGroup", CurrentUser.ChatGroup);
        }

        public async Task LeaveChatGroup(GroupType group, Guid id = default(Guid))
        {
            CurrentUser.ChatGroup = String.Empty;
            await Hub.InvokeAsync("JoinHubGroup", GetChatGroupName(group, id));
        }

        private string GetChatGroupName(GroupType group, Guid id = default(Guid))
        {
            if (id == Guid.Empty)
            {
                return group.ToDescriptionString();
            }
            else
            {
                return $"{group.ToDescriptionString()}-{id}";
            }
        }
    }
}
