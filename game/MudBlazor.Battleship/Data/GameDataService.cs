using Microsoft.EntityFrameworkCore;
using MudBlazor.Battleship.Models;
using System;
using System.Threading.Tasks;

namespace MudBlazor.Battleship.Data
{
    public interface IGameDbData
    {
        public GameDataUser GetUser(string username);
        public bool AddUser(User user);
    }
    public class GameData : IGameDbData
    {
        public GameDataContext Context { init; protected get; }
        public GameData(GameDataContext context)
        {
            Context = context;
        }

        public GameDataUser GetUser(string username)
        {
            var result = Context.Users.Find(username);
            return result;
        }
        public bool AddUser(User user)
        {
            GameDataUser DataUser = new GameDataUser { Id = user.Id, Username = user.Username };
            Context.Users.Add(DataUser);
            Context.SaveChanges();
            return true;
        }
    }
}
