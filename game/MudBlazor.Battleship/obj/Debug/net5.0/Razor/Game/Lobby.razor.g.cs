#pragma checksum "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3d9673eaffbadec54468ed9f335182829c82590"
// <auto-generated/>
#pragma warning disable 1591
namespace MudBlazor.Battleship.Game
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using MudBlazor.Battleship;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using MudBlazor.Battleship.Hubs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using MudBlazor.Battleship.Game;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\_Imports.razor"
using MudBlazor.Battleship.Shared;

#line default
#line hidden
#nullable disable
    public partial class Lobby : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Lobby</h3> ");
            __builder.OpenComponent<MudBlazor.MudButton>(1);
            __builder.AddAttribute(2, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 2 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
                                     () => LobbyMessage(user.Name, "hellloo")

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(4, "AddLobbyMessage");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "d-flex");
            __Blazor.MudBlazor.Battleship.Game.Lobby.TypeInference.CreateMudTextField_0(__builder, 8, 9, "Username", 10, 
#nullable restore
#line 5 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
                                                                     Variant.Outlined

#line default
#line hidden
#nullable disable
            , 11, 
#nullable restore
#line 5 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
                                user.Name

#line default
#line hidden
#nullable disable
            , 12, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => user.Name = __value, user.Name)));
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenComponent<MudBlazor.MudButton>(14);
            __builder.AddAttribute(15, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
                          () => SignIn()

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(16, "DisableElevation", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 6 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
                                                             true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(18, "Sign in");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 9 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
 foreach(var users in GameMode.GetUsers())
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<MudBlazor.MudText>(19);
            __builder.AddAttribute(20, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
#nullable restore
#line 11 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
__builder2.AddContent(21, users.Name);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(22, ";");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(23, "\r\n    ");
            __builder.OpenComponent<MudBlazor.MudText>(24);
            __builder.AddAttribute(25, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
#nullable restore
#line 12 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
__builder2.AddContent(26, users.ConnectionId);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(27, ";");
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 13 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
 if (isSignedIn)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
     foreach(var chat in _messages)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<MudBlazor.MudText>(28);
            __builder.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
#nullable restore
#line 19 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
__builder2.AddContent(30, $"{chat.Username}:{chat.Message}");

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 20 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Repos\MudBlazor.Battleship\game\MudBlazor.Battleship\Game\Lobby.razor"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MudBlazor.Battleship.Game.Lobby
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateMudTextField_0<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::MudBlazor.Variant __arg1, int __seq2, T __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg3)
        {
        __builder.OpenComponent<global::MudBlazor.MudTextField<T>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Variant", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591