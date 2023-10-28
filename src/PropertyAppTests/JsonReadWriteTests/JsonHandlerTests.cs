using PropertyApp.JsonReadWrite;
using PropertyApp.Model;
using System.Diagnostics.CodeAnalysis;

namespace PropertyAppTests.JsonReadWriteTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class JsonHandlerTests
{
    private JsonHandler<IssueModel> _jsonHandler;

    [Test]
    public void GetByIdGetsTheDesiredModel()
    {
        // Arrange
        _jsonHandler = new JsonHandler<IssueModel>();

        var expected = new IssueModel
        {
            Id = 3,
            ImagePath = @"path\to\file3",
            Title = "Broken lamp post",
            Description = "lampost toppled on John St",
            Location = new()
            {
                Latitude = 54.906545,
                Longitude = -1.380597
            },
            CapturedDateAndTime = new(2023, 10, 23, 16, 43, 20)
        };

        // Act
        var actual = _jsonHandler.GetById(3);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetByIdThatDoesNotExistThrowsKeyNotFoundException()
    {
        // Act
        var invalidGetByIdAction = () =>
        {
            _jsonHandler.GetById(99);
        };

        // Assert
        invalidGetByIdAction.Should().Throw<KeyNotFoundException>()
            .WithMessage("Model with Id 99 does not exist");
    }

    [Test]
    public void GetAllReturnsAllModelsInTheJson()
    {
        // Arrange
        _jsonHandler = new JsonHandler<IssueModel>();

        // Act
        var actual = _jsonHandler.GetAll();

        // Assert
        actual.Should().BeEquivalentTo(GetExpectedCollectionOfIssues());
    }

    public IEnumerable<IssueModel> GetExpectedCollectionOfIssues() => new List<IssueModel>
    {
        new()
        {
            Id = 1,
            ImagePath = @"path\to\file1",
            Title = "A dummy issue",
            Description = "Some silly billy spilled paint",
            Location = new()
            {
                Latitude = 52.577621,
                Longitude = -0.238101
            },
            CapturedDateAndTime = new(2023, 10, 20, 11, 45, 01)
        },
        new()
        {
            Id = 2,
            ImagePath = @"path\to\file2",
            Title = "Another dummy issue",
            Description = "A fence broke",
            Location = new()
            {
                Latitude = 54.853746,
                Longitude = -1.488033
            },
            CapturedDateAndTime = new(2023, 10, 21, 09, 43, 20)
        },
        new()
        {
            Id = 3,
            ImagePath = @"path\to\file3",
            Title = "Broken lamp post",
            Description = "lampost toppled on John St",
            Location = new()
            {
                Latitude = 54.906545,
                Longitude = -1.380597
            },
            CapturedDateAndTime = new(2023, 10, 23, 16, 43, 20)
        },
        new()
        {
            Id = 4,
            ImagePath = @"path\to\file4",
            Title = "Fallen tree",
            Description = "Tree fallen over in the park",
            Location = new()
            {
                Latitude = 54.901826,
                Longitude = -1.380238
            },
            CapturedDateAndTime = new(2023, 10, 25, 17, 43, 20)
        }
    }.AsEnumerable();
}
