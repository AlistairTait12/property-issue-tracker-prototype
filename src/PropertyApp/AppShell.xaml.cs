using PropertyApp.View;
using PropertyApp.ViewModel;

namespace PropertyApp;

public partial class AppShell : Shell
{
    public AppShell(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        Routing.RegisterRoute(nameof(IssuesListPage), typeof(IssuesListPage));
        Routing.RegisterRoute(nameof(SetTitleAndDescriptionPage), typeof(SetTitleAndDescriptionPage));
        Routing.RegisterRoute(nameof(IssueDetailsPage), typeof(IssueDetailsPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}
