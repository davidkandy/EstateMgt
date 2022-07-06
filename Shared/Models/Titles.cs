using System.Collections.Generic;

namespace Shared.Models
{
    public static class Titles
    {
        private static List<string> TitleList { get; set; } = new List<string>()
        {
            "Mr", "Mrs", "Miss", "Dr", "Prof", "Hon", "Engr", "Chief", "Arc", "Alh"
        };

        public static IEnumerable<string> GetTitles()
        {
            return TitleList;
        }
    }
}
