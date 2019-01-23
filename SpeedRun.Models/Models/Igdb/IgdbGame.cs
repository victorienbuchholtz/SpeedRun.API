namespace SpeedRun.Models.Models.Igdb
{
    public class IgdbGame
    {
        public int Id { get; set; }
        public IgdbScreenshot Cover { get; set; }
        public int First_release_date { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public IgdbScreenshot[] Screenshots { get; set; }
        public string Summary { get; set; }
    }
}