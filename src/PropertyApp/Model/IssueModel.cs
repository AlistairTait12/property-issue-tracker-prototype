namespace PropertyApp.Model;

public record IssueModel : IModel
{
    public int Id { get; set; }

    public string ImagePath { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IssueCoordinatesModel Location { get; set; }

    public DateTime CapturedDateAndTime { get; set; }
}
