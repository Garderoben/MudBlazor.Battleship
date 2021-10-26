namespace MudBlazor.Battleship.Helper
{
    public class Converter
    {
        private static string[] yCordinateLabels = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private static string[] XCordinateLabels = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        public int counter = 1;

        public static string GetRowLabel(int y)
        {
            return yCordinateLabels[y];
        }
        public static string GetColumnLabel(int y)
        {
            return XCordinateLabels[y];
        }
        public static string GetGridLabels(int count)
        {
            return "";
        }
    }
}
