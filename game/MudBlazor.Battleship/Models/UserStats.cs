namespace MudBlazor.Battleship.Models
{
    public class UserStats
    {
        public string Title { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }

        public UserStats(string title, double value, string description)
        {
            Title = title;
            Value = value;
            Description = description;
        }
    }
}
