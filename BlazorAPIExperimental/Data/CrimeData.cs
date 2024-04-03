namespace BlazorAPIExperimental.Data
{

    public class CrimeSummary
    {
        public int id { get; set; }
        public string datetime { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string gps { get; set; }
    }

}
