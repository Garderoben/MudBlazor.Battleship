using System;
using System.ComponentModel.DataAnnotations;

namespace MudBlazor.Battleship.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string ConnectionId { get; set; }
        
        public User(string username, string connectionId)
        {
            Username = username;
            ConnectionId = connectionId;
        }
    }
}