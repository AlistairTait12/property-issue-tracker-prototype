using PropertyApp.ModelHandling;

namespace PropertyAppTests.ModelHandlingTests;

public class ModelHandlerTests
{
    private ModelHandler _modelHandler;

    [Test]
    public void SetTitleSetsTheTitle()
    {
        // Arrange
        _modelHandler = new ModelHandler();
        _modelHandler.InitModel();

        // Act
        _modelHandler.SetTitle("Jerry's new issue");

        // Assert
        _modelHandler.GetTitle().Should().Be("Jerry's new issue");
    }

    [Test]
    public void SetTitleWithoutInitializingTheModelThrowsException()
    {
        // Arrange
        _modelHandler = new ModelHandler();

        // Act
        var setTitleAction = () => _modelHandler.SetTitle("Jerry's doomed to fail issue");
        var getTitleAction = () => _modelHandler.GetTitle();

        // Assert
        setTitleAction.Should().Throw<InvalidOperationException>()
            .WithMessage("_currentModel is null, unable to get or set property Title");
        getTitleAction.Should().Throw<InvalidOperationException>()
            .WithMessage("_currentModel is null, unable to get or set property Title");
    }

    [Test]
    public void GettingModelValuesAfterSettingThemThenClearingModelThrowsException()
    {
        // Arrange
        _modelHandler = new ModelHandler();
        _modelHandler.InitModel();
        _modelHandler.SetCapturedDateAndTime(new(2023, 10, 25, 12, 48, 59));
        _modelHandler.SetTitle("Doomed to fail issue");
        _modelHandler.SetDescription("Trying to get something on this model after the next step with throw error");

        // Act
        _modelHandler.ClearModel();
        var getDescriptionAction = () => _modelHandler.GetDescription();

        // Assert
        getDescriptionAction.Should().Throw<InvalidOperationException>()
            .WithMessage("_currentModel is null, unable to get or set property Description");
    }
}
