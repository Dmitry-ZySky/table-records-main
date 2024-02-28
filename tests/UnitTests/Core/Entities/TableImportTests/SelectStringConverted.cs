using UnitTests.Builders;
using Core.Entities.TableImportAggregate;
using Moq;
using Core.Enums;

namespace UnitTests.Core.Entities.TableImportTests;

public class SelectStringConverted
{
    [Fact]
    public void IsSelectStringConverted()
    {
        // Arrange
        var _tableImport = new TableImportBuilder();
        var tableImportMock = new Mock<TableImport>(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<Select>());

        // Act
        var selectConverted = tableImportMock.Object.ConvertSelectString(_tableImport.TestSelectString);

        // Assert
        Assert.Equal(Select.FirstOption, selectConverted);
    }
}
