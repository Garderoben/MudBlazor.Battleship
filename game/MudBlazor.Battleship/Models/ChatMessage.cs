using MudBlazor.Battleship.Enums;
using MudBlazor.Extensions;

namespace MudBlazor.Battleship.Models
{
    public class ChatMessage
    {
        public User User { get; set; }
        public string Message { get; set; }
        public ChatMessage(User user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
