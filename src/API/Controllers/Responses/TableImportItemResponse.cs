namespace API.Controllers.Responses;

public class TableImportItemResponse
{
    public int Id { get; set; }
    public string RequiredStringCol { get; set; } = string.Empty;
    public string StringCol { get; set; } = string.Empty;
    public DateTime DateCol { get; set; }
    public string SelectCol { get; set; } = string.Empty;

    public TableImportItemResponse(int id, string requiredStringColumn, string stringColumn, DateTime dateColumn, string selectColumn)
    {
        Id = id;
        RequiredStringCol = requiredStringColumn;
        StringCol = stringColumn;
        DateCol = dateColumn;
        SelectCol = selectColumn;
    }
}
