namespace Weather.Models
{
    public class WeatherData
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string LocalTime { get; set; }
        public double Temperature { get; set; } 
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
}
