namespace PunchService;

public class Punch
{
    public int Id { get; set; }
    public int PunchNumber { get; set; }
    public string PageAffected { get; set; }
    public string ChapterAffected { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public Document Document { get; set; }
}
