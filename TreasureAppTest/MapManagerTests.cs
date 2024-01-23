using TreasureApp.Interfaces;
using TreasureApp.Models;
using TreasureApp;
using NSubstitute;
using System.Reflection;
using System.Text;
using FluentAssertions;

namespace TreasureAppTest;

    [TestFixture]
    public class MapManagerTests
    {
    private MapManager _mapManager;

    [SetUp]
    public void Setup()
    {
        _mapManager = new MapManager();
    }


    //verify that CreateMap correctly initializes the map with the provided dimensions
    [Test]
    public void CreateMap_WithValidInput_InitializesMapWithCorrectDimensions()
    {
        // Arrange
        var filePath = @"Files/input.txt";

        // Act
        _mapManager.CreateMap(filePath);

        // Assert
        _mapManager.Map.Should().NotBeNull();
        _mapManager.Map.Width.Should().Be(3);
        _mapManager.Map.Height.Should().Be(4);
    }

    [Test]
    public void CreateMap_ThrowException_WhenInvalidInputFile()
    {
        // Arrange
        var filePath = @"Files/invalid.txt";

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => _mapManager.CreateMap(filePath));
    }

    //verify that CreateMap correctly adds a mountain to the map
    [Test]
    public void CreateMap_AddsMountainToMap_WhenInputContainsMountainData()
    {
        // Arrange
        var filePath = @"Files/input.txt";

        // Act
        _mapManager.CreateMap(filePath);

        // Assert
        _mapManager.Map.Cells[1, 0].IsMountain.Should().BeTrue();
    }

    //verify that CreateMap correctly adds treasures to the map
    [Test]
    public void CreateMap_AddsTreasureToMap_WhenInputContainsTreasureData()
    {
        // Arrange
        var filePath = @"Files/input.txt";

        // Act
        _mapManager.CreateMap(filePath);

        // Assert
        _mapManager.Map.Cells[1, 3].TreasureCount.Should().Be(3);
    }

    //verify that CreateMap correctly adds an adventurer to the map
    [Test]
    public void CreateMap_AddsAdventurerToMap_WhenInputContainsAdventurerData()
    {
        // Arrange
        var filePath = @"Files/input.txt";

        // Act
        _mapManager.CreateMap(filePath);

        // Assert
        _mapManager.Map.Adventurers.Should().HaveCount(1);
        _mapManager.Map.Adventurers[0].Name.Should().Be("Lara");
    }
}


