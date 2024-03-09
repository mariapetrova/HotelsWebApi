namespace Hotels.Api.Models
{
    public class TravelSite
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
