namespace MudBlazor.Battleship.Models
{
    public class ChatMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }

        public ChatMessage(string username, string message)
        {
            Username = username;
            Message = message;
        }
    }
}
