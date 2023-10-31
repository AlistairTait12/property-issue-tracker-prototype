using CommunityToolkit.Mvvm.ComponentModel;
using PropertyApp.Model;

namespace PropertyApp.ViewModel;

[QueryProperty(nameof(IssueModel), "IssueModel")]
public partial class IssueDetailsViewModel : ObservableObject
{
    [ObservableProperty]
    IssueModel issueModel;
}
