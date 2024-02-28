using Core.Interfaces;
using Core.Enums;

namespace Core.Entities.TableImportAggregate;
public class TableImport : BaseEntity, IAggregateRoot
{
    public string RequiredStringColumn { get; private set; } = string.Empty;
    public string StringColumn { get; private set; } = string.Empty;
    public DateTime DateColumn { get; private set; }
    public Select SelectColumn { get; private set; }

    public TableImport(){}

    public TableImport(string requiredStringColumn, string stringColumn, DateTime dateColumn, Select selectColumn)
    {
        RequiredStringColumn = requiredStringColumn;
        StringColumn = stringColumn;
        DateColumn = dateColumn;
        SelectColumn = selectColumn;
    }

    #region methods

    public Select ConvertSelectString(string selectString)
    {
        SelectColumn = selectString switch
        {
            "First" or "10" => Select.FirstOption,
            "Second" or "20" => Select.SecondOption,
            "Third" or "30" => Select.ThirdOption,
            "Unknown" or "0" or _ => Select.Unknown,
        };
        return SelectColumn;
    }

    public void UpdateRecord(int id, string requiredStringColumn, string stringColumn, DateTime dateColumn, Select selectColumn)
    {
        Id = id;
        RequiredStringColumn = requiredStringColumn;
        StringColumn = stringColumn;
        DateColumn = dateColumn;
        SelectColumn = selectColumn;
    }

    #endregion
}

