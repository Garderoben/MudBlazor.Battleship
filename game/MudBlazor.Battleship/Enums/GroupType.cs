using System.ComponentModel;

namespace MudBlazor.Battleship.Enums
{
    public enum GroupType
    {
        [Description("global")]
        Global,
        [Description("lobby")]
        Lobby,
        [Description("game")]
        Game
    }
}
