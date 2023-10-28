using Microsoft.Extensions.DependencyInjection;
using PropertyApp.Model;
using PropertyApp.ModelHandling;
using System.Diagnostics.CodeAnalysis;

namespace PropertyAppTests.ModelHandlingTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class ModelHandlerTests
{
    private ModelHandler _modelHandler;
    private IServiceProvider _serviceProvider;

    [SetUp]
    public void SetUp()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ModelHandler>();
        _serviceProvider = services.BuildServiceProvider();
        _modelHandler = _serviceProvider.GetRequiredService<ModelHandler>();
    }

    [TearDown]
    public void TearDown()
    {
        _modelHandler.ClearModel();
    }

    [Ignore("TODO: Need to learn implementing singleton pattern properly, come back to this one")]
    [Test]
    public void ThereCanBeOnlyOne()
    {
        // Act
        var attemptToCreateSecondInstance = () =>
        {
            var kurganInstance = new ModelHandler();
        };

        // Assert
        attemptToCreateSecondInstance.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot create more than one instance of ModelHandler class");
    }

    [Test]
    public void SetImagePathSetsTheImagePath()
    {
        // Arrange
        _modelHandler.InitModel();

        // Act
        _modelHandler.SetImagePath(@"D:\ummy\image\path");

        // Assert
        _modelHandler.GetImagePath().Should().Be(@"D:\ummy\image\path");
    }

    [Test]
    public void SetTitleSetsTheTitle()
    {
        // Arrange
        _modelHandler.InitModel();

        // Act
        _modelHandler.SetTitle("Jerry's new issue");

        // Assert
        _modelHandler.GetTitle().Should().Be("Jerry's new issue");
    }

    [Test]
    public void SetDescriptionSetsTheDescription()
    {
        // Arrange
        _modelHandler.InitModel();

        // Act
        _modelHandler.SetDescription("Description of the issue currently in the handler");

        // Assert
        _modelHandler.GetDescription().Should().Be("Description of the issue currently in the handler");
    }

    [Test]
    public void SetLocationSetsTheLocation()
    {
        // Arrange
        _modelHandler.InitModel();
        var expected = new IssueCoordinatesModel
        {
            Latitude = 52.577621,
            Longitude = -0.238101
        };

        // Act
        var coordinates = new IssueCoordinatesModel
        {
            Latitude = 52.577621,
            Longitude = -0.238101
        };

        _modelHandler.SetLocation(coordinates);

        // Assert
        _modelHandler.GetIssueCoordinates().Should().BeEquivalentTo(expected);
    }

    [Test]
    public void SetCapturedDateAndTimeSetsTheCapturedDateAndTime()
    {
        // Arrange
        _modelHandler.InitModel();

        // Act
        _modelHandler.SetCapturedDateAndTime(new(2023, 10, 26, 12, 48, 52));

        // Assert
        _modelHandler.GetCapturedDateAndTime().Should().Be(new(2023, 10, 26, 12, 48, 52));
    }

    [Test]
    public void SetTitleWithoutInitializingTheModelThrowsException()
    {
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
