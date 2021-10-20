using System;
using System.ComponentModel.DataAnnotations;

namespace MudBlazor.Battleship.Models
{
    public class GameDataUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }

    public class User : GameDataUser
    {
        public string ChatGroup { get; set; }
        public string ConnectionId { get; set; }

        public User() { }
        public User(Guid id, string username, string chatgroup, string connectionId)
        {
            ChatGroup = chatgroup;
            ConnectionId = connectionId;
        }
    }
}