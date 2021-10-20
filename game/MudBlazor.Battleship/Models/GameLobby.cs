using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MudBlazor.Battleship.Models
{
    public class GameLobby
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Name { get; set; }
        public List<User> Players { get; set; }
        public bool Private { get; set; }

        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }

        public GameLobby() { }
        public GameLobby(Guid id, string name, List<User> players, bool privete, string password)
        {
            Id = id;
            Name = name;
            Players = players;
            Private = privete;
            Password = password;
        }
    }
}
