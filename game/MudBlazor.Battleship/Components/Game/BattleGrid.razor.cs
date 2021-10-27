using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Battleship.Models;
using System.Collections.Generic;

namespace MudBlazor.Battleship.Components
{
    public partial class BattleGrid
    {
        public List<string> RowLabels = new() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public List<string> ColumnLabels = new() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        public List<GridSection> Sections { get; set; }

        public BattleGrid()
        {
            Sections = new List<GridSection>();

            for(int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    Sections.Add(new GridSection(r, c));
                }
            }
        }
    }
}