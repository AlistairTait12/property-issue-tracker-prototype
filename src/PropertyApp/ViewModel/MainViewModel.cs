using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PropertyApp.View;

namespace PropertyApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    public async Task GoHomeAsync() => await Shell.Current.GoToAsync(nameof(MainPage), true);

    [RelayCommand]
    public async Task GoToIssuesAsync() => await Shell.Current.GoToAsync(nameof(IssuesListPage), true);

    [RelayCommand]
    public async Task GoToCaptureAsync() => await Shell.Current.GoToAsync(nameof(SetTitleAndDescriptionPage), true);

    [RelayCommand]
    public async Task GoToAboutAsync() => await Shell.Current.GoToAsync(nameof(AboutPage), true);
}
