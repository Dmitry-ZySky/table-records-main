using Core.Entities.TableImportAggregate;
using Core.Enums;

namespace UnitTests.Builders;

public class TableImportBuilder
{
    private TableImport _tableImport;

    public int TestId => 1;
    public string TestRequiredStringColumn => "Str1";
    public string TestStringColumn => "Str2";
    public DateTime TestDateColumn = new DateTime(1998, 7, 24);
    public Select TestSelect => Select.FirstOption;
    public string TestSelectString => "First";
    public TableImport TestTableImport { get; }

    public TableImportBuilder()
    {
        TestTableImport = new TableImport(TestRequiredStringColumn, TestStringColumn, TestDateColumn, TestSelect);
        _tableImport = WithDefaultEntityValues();
    }

    public TableImport Build()
    {
        return _tableImport;
    }

    public TableImport WithDefaultEntityValues()
    {
        _tableImport = new TableImport(TestRequiredStringColumn, TestStringColumn, TestDateColumn, TestSelect);
        return _tableImport;
    }

    public TableImport WithEmptyValues()
    {
        _tableImport = new TableImport("", "", DateTime.UtcNow, Select.Unknown);
        return _tableImport;
    }
}
