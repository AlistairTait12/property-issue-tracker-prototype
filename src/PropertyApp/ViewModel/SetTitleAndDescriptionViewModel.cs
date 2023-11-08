using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PropertyApp.JsonReadWrite;
using PropertyApp.Model;
using PropertyApp.ModelHandling;
using PropertyApp.View;

namespace PropertyApp.ViewModel;

public partial class SetTitleAndDescriptionViewModel : ObservableObject
{
    private readonly IModelHandler _modelHandler;
    private readonly IJsonHandler<IssueModel> _jsonHandler;

    public SetTitleAndDescriptionViewModel(IModelHandler modelHandler)
    {
        _modelHandler = modelHandler;
        _modelHandler.InitModel();
    }

    [ObservableProperty]
    string title;

    [RelayCommand]
    public async Task SaveModel()
    {
        AddTitle();
        _modelHandler.SetCapturedDateAndTime(DateTime.Now);
        // TODO: Add logic to be able to save the model to storage
        var modelToSave = new IssueModel
        {
            Title = _modelHandler.GetTitle(),
            CapturedDateAndTime = _modelHandler.GetCapturedDateAndTime()
        };

        await Shell.Current.GoToAsync(nameof(MainPage), true);
    }

    [RelayCommand]
    public void AddTitle()
    {
        _modelHandler.SetTitle(Title);
    }
}
