using System.Text.Json.Serialization;

namespace PropertyApp.Model;

public class IssueCoordinatesModel
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
