using PropertyApp.ViewModel;

namespace PropertyApp.View;

public partial class IssuesListPage : ContentPage
{
    public IssuesListPage(IssuesListViewModel issuesListViewModel)
    {
        InitializeComponent();
        BindingContext = issuesListViewModel;
    }
}
