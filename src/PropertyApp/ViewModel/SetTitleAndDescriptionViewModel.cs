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

    public SetTitleAndDescriptionViewModel(IModelHandler modelHandler,
        IJsonHandler<IssueModel> jsonHandler)
    {
        _modelHandler = modelHandler;
        _jsonHandler = jsonHandler;
        _modelHandler.InitModel();
    }

    [ObservableProperty]
    string title;

    [RelayCommand]
    public async Task SaveModel()
    {
        AddTitle();
        _modelHandler.SetCapturedDateAndTime(DateTime.Now);
        var modelToSave = new IssueModel
        {
            Title = _modelHandler.GetTitle(),
            CapturedDateAndTime = _modelHandler.GetCapturedDateAndTime()
        };

        await _jsonHandler.AddAsync(modelToSave);

        await Shell.Current.GoToAsync(nameof(MainPage), true);
    }

    [RelayCommand]
    public void AddTitle()
    {
        _modelHandler.SetTitle(Title);
    }
}
