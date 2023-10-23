namespace PropertyApp.Model;

public record IssueModel
{
    public string ImagePath { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Location Location { get; set; }

    public DateTime CapturedDateAndTime { get; set; }
}
