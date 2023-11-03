﻿using PropertyApp.Model;
using System.Diagnostics.CodeAnalysis;

namespace PropertyAppTests.Model;

[ExcludeFromCodeCoverage]
[TestFixture]
public class IssueModelTests
{
    [Test]
    public void GetShortDescriptionReturnsFirst200CharactersWithEllipsis()
    {
        // Arrange
        var issueModel = new IssueModel
        {
            Description = GetLongDescription()
        };

        var expected =
            @"blah blah blah blah blah blah blah blah blah blah "
            + "blah blah blah blah blah blah blah blah blah blah "
            + "blah blah blah blah blah blah blah blah blah blah "
            + "blah blah blah blah blah blah blah blah blah blah ...";

        // Act
        var actual = issueModel.ShortDescription;

        // Assert
        actual.Should().Be(expected);
    }

    [Test]
    public void GetShortDescriptionWhenLessThan200CharactersJustReturnsDescriptionWithoutEllipsis()
    {
        // Arrange
        var issueModel = new IssueModel
        {
            Description = "Just a short description"
        };

        // Act
        var actual = issueModel.ShortDescription;

        // Assert
        actual.Should().Be("Just a short description");
    }

    [Test]
    public void GetShortDescriptionWhenExactly200CharactersOmitsEllipsis()
    {
        // Arrange
        var issueModel = new IssueModel
        {
            Description = GetExactlyTwoHundredCharacters()
        };

        // Act
        var actual = issueModel.ShortDescription;

        // Assert
        actual.Should().Be(GetExactlyTwoHundredCharacters());
    }

    private static string GetLongDescription() =>
        @"blah blah blah blah blah blah blah blah blah blah "
        + "blah blah blah blah blah blah blah blah blah blah "
        + "blah blah blah blah blah blah blah blah blah blah "
        + "blah blah blah blah blah blah blah blah blah blah "
        + "blah blah blah blah blah blah blah blah blah blah";

    private static string GetExactlyTwoHundredCharacters() =>
        @"blah blah blah blah blah blah blah blah blah blah "
        + "blah blah blah blah blah blah blah blah blah blah "
        + "blah blah blah blah blah blah blah blah blah blah "
        + "blah blah blah blah blah blah blah blah blah blahh";
}
