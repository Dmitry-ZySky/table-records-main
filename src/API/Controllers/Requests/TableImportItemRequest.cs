namespace API.Controllers.Requests;

public class TableImportItemRequest
{
    public string RequiredStringCol { get; set; } = string.Empty;
    public string StringCol { get; set; } = string.Empty;
    public DateTime DateCol { get; set; }
    public string SelectCol { get; set; } = string.Empty;
}
