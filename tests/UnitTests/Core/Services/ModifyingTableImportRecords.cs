using Core.Entities.TableImportAggregate;
using Core.Interfaces;
using Moq;
using UnitTests.Builders;

namespace UnitTests.Core.Services;

public class ModifyingTableImportRecords
{
    private readonly TableImportBuilder _tableImport = new TableImportBuilder();
    private readonly Mock<IRepository<TableImport>> _mockTableImportRepository = new();
    private readonly Mock<IAppLogger<TableImport>> _mockLogger = new();

    [Fact]
    public void ShouldAddTableImport()
    {
        // Arrange
        var tableImports = new List<TableImport>();

        _mockTableImportRepository
            // Act
            .Setup(p => p.AddAsync(It.IsAny<TableImport>()))
            // Assert
            .Callback((TableImport p) => tableImports.Add(p));
    }
}
