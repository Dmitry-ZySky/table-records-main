using System.ComponentModel.DataAnnotations;

namespace API.Controllers.Requests;

[Serializable]
public class ImportFileRequest
{
    [Display(Name = "файл")]
    public IFormFile? File { get; set; }
}