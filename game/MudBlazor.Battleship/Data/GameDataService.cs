using Microsoft.EntityFrameworkCore;
using MudBlazor.Battleship.Models;
using System;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Data
{
    public interface IGameDbData
    {
        public User GetUser(string username);
        public bool AddUser(User user);
    }
    public class GameData : IGameDbData
    {
        public GameDataContext Context { init; protected get; }
        public GameData(GameDataContext context)
        {
            Context = context;
        }

        public User GetUser(string username)
        {
            var result = Context.Users.Find(username);
            return result;

        }
        public bool AddUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return true;
        }
    }
}
