using PropertyApp.ViewModel;

namespace PropertyApp;

public partial class App : Application
{
    public App(MainViewModel mainViewModel)
    {
        InitializeComponent();

        MainPage = new AppShell(mainViewModel);
    }
}
