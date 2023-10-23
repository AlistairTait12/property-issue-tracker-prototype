using PropertyApp.Model;

namespace PropertyApp.ModelHandling;

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
        throw new NotImplementedException();
    }

    public string GetImagePath()
    {
        throw new NotImplementedException();
    }

    public void SetTitle(string title)
    {
        if (_currentModel is null)
        {
            throw new InvalidOperationException
                ($"{nameof(_currentModel)} is null, unable to set property {nameof(_currentModel.Title)}");
        }

        _currentModel.Title = title;
    }

    public string GetTitle()
    {
        if (_currentModel is null)
        {
            throw new InvalidOperationException
                ($"{nameof(_currentModel)} is null, unable to get property {nameof(_currentModel.Title)}");
        }

        return _currentModel.Title;
    }

    public void SetDescription(string description)
    {
        throw new NotImplementedException();
    }

    public string GetDescription()
    {
        throw new NotImplementedException();
    }

    public void SetLocation(Location location)
    {
        throw new NotImplementedException();
    }

    public Location GetLocation()
    {
        throw new NotImplementedException();
    }

    public void SetCapturedDateAndTime(DateTime capturedDateAndTime)
    {
        throw new NotImplementedException();
    }

    public DateTime GetCapturedDateAndTime()
    {
        throw new NotImplementedException();
    }
}
