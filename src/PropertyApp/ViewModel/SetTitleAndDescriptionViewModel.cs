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

    [ObservableProperty]
    string description;

    [RelayCommand]
    public async Task SaveModel()
    {
        _modelHandler.SetTitle(Title);
        _modelHandler.SetDescription(Description);
        _modelHandler.SetCapturedDateAndTime(DateTime.Now);
        // TODO, surely there must be a better way... What about a method on the handler which spits
        // out what it has recorded?
        var modelToSave = new IssueModel
        {
            Title = _modelHandler.GetTitle(),
            Description = _modelHandler.GetDescription(),
            CapturedDateAndTime = _modelHandler.GetCapturedDateAndTime()
        };

        await _jsonHandler.AddAsync(modelToSave);

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
    }
}
