namespace FunnelTrendRadarAPI.Models.Entities
{
    public class Trend
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Impact { get; set; } = null!;
        public string TimeFrame { get; set; } = null!;
        public int Views { get; set; } = 0;
        public Category Category { get; set; }
        public TrendType TrendType { get; set; }
    }

    public enum Category
    {
        Labor_Shortage,
        Digitalization,
        As_a_Service,
        Sustainability,
        Autonomous_Systems,
        AI,
        Robotics,
        Digital_and_Cloud,
        Other
    }

    public enum TrendType
    {
        Social,
        Technology
    }
}
