using API.Controllers.Requests;
using API.Controllers.Responses;
using Core.Entities.TableImportAggregate;
using Core.Enums;
using Core.Interfaces;
using Core.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TableImportController : ControllerBase
{
    private readonly ITableImportService _tableImportService;
    private readonly IAppLogger<TableImport> _logger;

    public TableImportController(ITableImportService tableImportService, IAppLogger<TableImport> logger)
    {
        _tableImportService = tableImportService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult> GetList()
    {
        try
        {
            _logger.Information("API.Controllers.TableImportController: GetList()");
            var tableImports = await _tableImportService.GetAllAsync();

            var tableImportsItemResponse = new List<TableImportItemResponse>();

            foreach (var tableImport in tableImports) 
            {
                tableImportsItemResponse.Add(new TableImportItemResponse(tableImport.Id, tableImport.RequiredStringColumn, tableImport.StringColumn, tableImport.DateColumn, SelectStringFormatter(tableImport.SelectColumn)));
            }

            return Ok(tableImportsItemResponse);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"API.Controllers.TableImportController: GetList() - Failed: {ex.Message}");
        }
        return BadRequest("GetList() - Failed");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            _logger.Information("API.Controllers.TableImportController: Get(int id)");
            var tableImport = await _tableImportService.GetByIdAsync(id);

            return Ok(new TableImportItemResponse(tableImport.Id, tableImport.RequiredStringColumn, tableImport.StringColumn, tableImport.DateColumn, SelectStringFormatter(tableImport.SelectColumn)));
        } 
        catch (Exception ex)
        {
            _logger.Error(ex, $"API.Controllers.TableImportController: Get(int id) - Failed: {ex.Message}");
        }
        return BadRequest("Get(int id) - Failed");
    }

    [HttpPost]
    public async Task<ActionResult> Post(TableImportItemRequest tableImportItemRequest)
    {
        try
        {
            _logger.Information("API.Controllers.TableImportController: Post(TableImportItemRequest tableImportItemRequest)");

            var tableImportOperation = new TableImportOperation
            {
                RequiredStringColumn = tableImportItemRequest.RequiredStringCol,
                StringColumn = tableImportItemRequest.StringCol,
                DateColumn = tableImportItemRequest.DateCol,
                SelectColumn = new TableImport().ConvertSelectString(tableImportItemRequest.SelectCol)
            };

            var tableImport = await _tableImportService.CreateAsync(tableImportOperation);

            var TableImportItemResponse = new TableImportItemResponse(tableImport.Id, tableImport.RequiredStringColumn, tableImport.StringColumn, tableImport.DateColumn, SelectStringFormatter(tableImport.SelectColumn));

            return base.Ok((object)TableImportItemResponse);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"API.Controllers.TableImportController: Post(string requiredStringColumn, string stringColumn, DateTime dateColumn, string selectColumn) - Failed: {ex.Message}");
        }
        return BadRequest("Post(TableImport tableImport) - Failed");
    }

    [HttpPost("Batch")]
    public async Task<ActionResult> Batch([FromBody] IEnumerable<TableImportItemRequest> tableImportItemRequests)
    {
        try
        {
            _logger.Information("API.Controllers.TableImportController: Post(TableImportItemRequest tableImportItemRequest)");

            var dto = new List<TableImportOperation>();

            foreach (var tableImportItemRequest in tableImportItemRequests)
            {
                dto.Add(
                    new TableImportOperation
                    {
                        RequiredStringColumn = tableImportItemRequest.RequiredStringCol,
                        StringColumn = tableImportItemRequest.StringCol,
                        DateColumn = tableImportItemRequest.DateCol,
                        SelectColumn = new TableImport().ConvertSelectString(tableImportItemRequest.SelectCol)
                    }
                );
            }

            var TableImports = await _tableImportService.BatchAsync(dto);

            var TableImportItemResponse = new List<TableImportItemResponse>();

            foreach (var TableImport in TableImports)
            {
                TableImportItemResponse.Add(new TableImportItemResponse(TableImport.Id, TableImport.RequiredStringColumn, TableImport.StringColumn, TableImport.DateColumn, SelectStringFormatter(TableImport.SelectColumn)));
            }

            return Ok(TableImportItemResponse);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"API.Controllers.TableImportController: Post(List<TableImportItemRequest> - Failed: {ex.Message}");
        }
        return BadRequest("Post(TableImport TableImport) - Failed");
    }

    private string SelectStringFormatter(Select select)
    {
        var selectString = select switch
        {
            Select.FirstOption => "First",
            Select.SecondOption => "Second",
            Select.ThirdOption => "Third",
            _ => "Unknown",
        };
        return selectString;
    }
}
