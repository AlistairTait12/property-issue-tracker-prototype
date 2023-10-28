using PropertyApp.Model;

namespace PropertyApp.ModelHandling;

// TODO: Implement the singleton pattern
public class ModelHandler : IModelHandler
{
    private IssueModel _currentModel;

    public void InitModel()
    {
        _currentModel = new IssueModel();
    }

    public void ClearModel()
    {
        _currentModel = null;
    }

    public void SetImagePath(string path)
    {
        ValidateModel(nameof(_currentModel.ImagePath));
        _currentModel.ImagePath = path;
    }

    public string GetImagePath()
    {
        ValidateModel(nameof(_currentModel.ImagePath));
        return _currentModel.ImagePath;
    }

    public void SetTitle(string title)
    {
        ValidateModel(nameof(_currentModel.Title));
        _currentModel.Title = title;
    }

    public string GetTitle()
    {
        ValidateModel(nameof(_currentModel.Title));
        return _currentModel.Title;
    }

    public void SetDescription(string description)
    {
        ValidateModel(nameof(_currentModel.Description));
        _currentModel.Description = description;
    }

    public string GetDescription()
    {
        ValidateModel(nameof(_currentModel.Description));
        return _currentModel.Description;
    }

    public void SetLocation(IssueCoordinatesModel location)
    {
        ValidateModel(nameof(_currentModel.Location));
        _currentModel.Location = location;
    }

    public IssueCoordinatesModel GetIssueCoordinates()
    {
        ValidateModel(nameof(_currentModel.Location));
        return _currentModel.Location;
    }

    public void SetCapturedDateAndTime(DateTime capturedDateAndTime)
    {
        ValidateModel(nameof(_currentModel.CapturedDateAndTime));
        _currentModel.CapturedDateAndTime = capturedDateAndTime;
    }

    public DateTime GetCapturedDateAndTime()
    {
        ValidateModel(nameof(_currentModel.CapturedDateAndTime));
        return _currentModel.CapturedDateAndTime;
    }

    private void ValidateModel(string propName)
    {
        if (_currentModel is null)
        {
            throw new InvalidOperationException
                ($"{nameof(_currentModel)} is null, unable to get or set property {propName}");
        }
    }
}
