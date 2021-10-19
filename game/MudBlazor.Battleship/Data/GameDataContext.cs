using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Battleship.Models;

namespace MudBlazor.Battleship.Data
{
    public class GameDataContext : DbContext
    {
        public GameDataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
