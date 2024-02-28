using Core.Enums;

namespace Core.Services.Dto;

/// <summary>
/// Импорт таблицы
/// </summary>
public class TableImportOperation
{
    public string RequiredStringColumn { get; set; } = string.Empty;
    public string StringColumn { get; set; } = string.Empty;
    public DateTime DateColumn { get; set; }
    public Select SelectColumn { get; set; }
}