using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PropertyApp.JsonReadWrite;
using PropertyApp.Model;
using PropertyApp.View;

namespace PropertyApp.ViewModel;

public partial class IssuesListViewModel : ObservableObject
{
    private readonly IJsonHandler<IssueModel> _issueModelJsonHandler;

    public IssuesListViewModel(IJsonHandler<IssueModel> issueModelJsonHandler)
    {
        _issueModelJsonHandler = issueModelJsonHandler;
    }

    public IEnumerable<IssueModel> IssueModels => _issueModelJsonHandler.GetAll();

    // TODO: Populate a list of issues to be presented to user (so it should require a JSON Handler)
    // TODO: If a user clicks on one, it should take them to the details page for that issue
    [RelayCommand]
    public async Task GoToIssueDetailsAsync(IssueModel issueModel)
    {
        if (issueModel == null)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(IssueDetailsPage), true,
            new Dictionary<string, object>()
            {
                { "IssueModel", issueModel }
            });
    }
}
