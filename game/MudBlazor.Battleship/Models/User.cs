using System;
using System.ComponentModel.DataAnnotations;

namespace MudBlazor.Battleship.Models
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(12, ErrorMessage = "Lobby name can't be more than 12 characters.", MinimumLength = 4)]
        public string Username { get; set; }
        public string ConnectionId { get; set; }

        public User() { }
        public User(string username, string connectionId)
        {
            Username = username;
            ConnectionId = connectionId;
        }
    }
}