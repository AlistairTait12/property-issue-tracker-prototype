using CommunityToolkit.Mvvm.ComponentModel;
using PropertyApp.JsonReadWrite;
using PropertyApp.Model;

namespace PropertyApp.ViewModel;

public class IssuesListViewModel : ObservableObject
{
    private readonly IJsonHandler<IssueModel> _issueModelJsonHandler;

    public IssuesListViewModel(IJsonHandler<IssueModel> issueModelJsonHandler)
    {
        _issueModelJsonHandler = issueModelJsonHandler;
    }

    public IEnumerable<IssueModel> IssueModels => GetIssueModels();

    // TODO: Populate a list of issues to be presented to user (so it should require a JSON Handler)
    // TODO: If a user clicks on one, it should take them to the details page for that issue

    // HACK: Just plonking this here to try it out
    private IEnumerable<IssueModel> GetIssueModels() => new List<IssueModel>()
    {
        new()
        {
            Id = 1,
            Title = "Dummy issue 1",
            Description = "Just some dummy information about the test, this will be "
                        + "more information later and I'm just babbling on to test.",
            ImagePath = "Test",
            CapturedDateAndTime = new(2023, 10, 30, 12, 50, 22),
            Location = new()
            {
                Latitude = 54.853746,
                Longitude = -1.488033
            }
        },
        new()
        {
            Id = 2,
            Title = "A spooky issue",
            Description = "A spooky issue because it is Halloween",
            ImagePath = "Test",
            CapturedDateAndTime = new(2023, 10, 31, 12, 16, 12),
            Location = new()
            {
                Latitude = 54.901826,
                Longitude = -1.380238
            }
        }
    };
}
