using System.Collections.Generic;

namespace Client.Models
{
    public static class Nigeria
    {
        public static string Country { get; set; } = "Nigeria";

        public static List<string> States { get; set; } = new List<string>() {
        "Abia","Adamawa","Akwa Ibom","Anambra","Bauchi","Bayelsa","Benue","Borno","Cross River",
        "Delta","Ebonyi","Edo","Ekiti","Enugu","Gombe","Imo","Jigawa","Kaduna","Kano","Katsina",
        "Kebbi","Kogi","Kwara","Lagos","Nasarawa","Niger","Ogun","Ondo","Osun","Oyo","Plateau",
        "Rivers","Sokoto","Taraba","Yobe","Zamfara","FCT"};

        public static List<string> Cities { get; set; } = new List<string>() {
        "Abuja","Lagos","Kano","Kaduna","Port-Harcourt","Ibadan","Enugu","Maiduguri","Katsina",
        "Sokoto","Gombe","Bauchi","Jos","Ilorin","Yola","Gusau","Birnin-Kebbi","Dutse","Damaturu","Jalingo",
        "Calabar","Yenagoa","Abeokuta","Akure","Minna","Lafia","Lokoja","Owerri","Ado-Ekiti","Awka","Makurdi",
        "Uyo","Abakaliki","Asaba","Oshogbo","Umuahia"};

        public static string GetCountry()
        {
            return Country;
        }

        public static IEnumerable<string> GetStates()
        {
            return States;
        }

        public static IEnumerable<string> GetCities()
        {
            return Cities;
        }
    }
}
