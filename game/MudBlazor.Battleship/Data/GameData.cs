using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Battleship.Models;

namespace MudBlazor.Battleship.Data
{
    public class GameData : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string DbPath { get; private set; }

        public GameData()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}battleship.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
