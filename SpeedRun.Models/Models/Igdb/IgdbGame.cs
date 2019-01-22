public class IgdbGame
{
    public int id { get; set; }
    public IgdbScreenshot cover { get; set; }
    public int first_release_date { get; set; }
    public string name { get; set; }
    public float rating { get; set; }
    public IgdbScreenshot[] screenshots { get; set; }
    public string summary { get; set; }
}