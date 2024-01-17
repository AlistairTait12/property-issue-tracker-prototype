using PropertyApp.ViewModel;

namespace PropertyApp.View;

public partial class IssuesListPage : ContentPage
{
    private readonly IssuesListViewModel _viewModel;

    public IssuesListPage(IssuesListViewModel issuesListViewModel)
    {
        InitializeComponent();
        _viewModel = issuesListViewModel;
        BindingContext = _viewModel;
    }

    // TODO: Is this the best way? Wouldn't it be better to get the observable property to do it?
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _viewModel.RefreshIssueModels();
        base.OnNavigatedTo(args);
    }
}
