using System.Text.Json.Serialization;

namespace PropertyApp.Model;

public record IssueModel : IModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("imagePath")]
    public string ImagePath { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("location")]
    public IssueCoordinatesModel Location { get; set; }

    [JsonPropertyName("capturedDateAndTime")]
    public DateTime CapturedDateAndTime { get; set; }

    public string ShortDescription => Description.Length > 200
        ? $"{Description[..200]}..."
        : Description;

    // TODO: unit tests
    public string ShortTitle => Title.Length > 30
        ? $"{Title[..50]}..."
        : Title;

    public string CalendarDateAndTime =>
        $"{CapturedDateAndTime.ToString("ddd d MMM yyyy, hh:mm")}{CapturedDateAndTime.ToString("tt").ToLower()}";
}
