using PropertyApp.View;

namespace PropertyApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(IssueDetailsPage), typeof(IssueDetailsPage));
    }
}
