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
    public void SetTitleWithoutInitializingTheModelThrowsError()
    {
        // Arrange
        _modelHandler = new ModelHandler();

        // Assert
        Assert.That(() => _modelHandler.SetTitle("Jerry's doomed to fail issue"), Throws.TypeOf<InvalidOperationException>());
        Assert.That(() => _modelHandler.GetTitle(), Throws.TypeOf<InvalidOperationException>());
    }
}
