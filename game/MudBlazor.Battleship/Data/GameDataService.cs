using Microsoft.EntityFrameworkCore;
using MudBlazor.Battleship.Models;
using System;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Data
{
    public interface IGameData
    {
        public Task<User> GetUser(string username);
        public Task<bool> AddUser(User user);
    }
    public class GameData : IGameData
    {
        public GameDataContext Context { init; protected get; }
        public GameData(GameDataContext context)
        {
            Context = context;
        }

        public async Task<User> GetUser(string username)
        {
            var result = await Context.Users.FindAsync(username);
            return result;
        }
        public async Task<bool> AddUser(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();

            return true;
        }
    }
}
