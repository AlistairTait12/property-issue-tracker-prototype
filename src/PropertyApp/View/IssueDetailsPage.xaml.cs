using PropertyApp.ViewModel;

namespace PropertyApp.View;

public partial class IssueDetailsPage : ContentPage
{
    public IssueDetailsPage(IssueDetailsViewModel issueDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = issueDetailsViewModel;
    }
}