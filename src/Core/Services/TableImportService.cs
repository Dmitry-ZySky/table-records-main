using Ardalis.GuardClauses;
using Core.Entities.TableImportAggregate;
using Core.Interfaces;
using Core.Services.Dto;

namespace Core.Services;

public class TableImportService : ITableImportService
{
    private readonly IRepository<TableImport> _tableImportRepository;
    private readonly IAppLogger<TableImport> _logger;

    public TableImportService(IRepository<TableImport> tableImportRepository, IAppLogger<TableImport> logger)
    {
        _tableImportRepository = tableImportRepository;
        _logger = logger;
    }

    public async Task<TableImport> CreateAsync(TableImportOperation tableImportOperation)
    {
        _logger.Information("Core.Services.TableImportService: CreateAsync()");

        Guard.Against.NullOrEmpty(tableImportOperation.RequiredStringColumn, nameof(tableImportOperation.RequiredStringColumn));

        var tableImport = new TableImport(
            tableImportOperation.RequiredStringColumn,
            tableImportOperation.StringColumn,
            tableImportOperation.DateColumn,
            tableImportOperation.SelectColumn);

        return await _tableImportRepository.AddAsync(tableImport);
    }

    public async Task<IEnumerable<TableImport>> BatchAsync(IEnumerable<TableImportOperation> tableImportOperations)
    {
        _logger.Information("Core.Services.TableImportService: BatchAsync()");

        var entites = new List<TableImport>();

        foreach (var tableImportOperation in tableImportOperations)
        {
            entites.Add(
                new TableImport
                (
                    tableImportOperation.RequiredStringColumn,
                    tableImportOperation.StringColumn,
                    tableImportOperation.DateColumn,
                    tableImportOperation.SelectColumn
                )
            );
        }

        return await _tableImportRepository.AddRangeAsync(entites);

    }

    public async Task<TableImport> GetByIdAsync(int id)
    {
        _logger.Information("Core.Services.TableImportService: GetByIdAsync()");

        return await _tableImportRepository.GetByIdAsync(id) ?? new TableImport();
    }

    public async Task<IEnumerable<TableImport>> GetAllAsync()
    {
        _logger.Information("Core.Services.TableImportService: GetAllAsync()");

        return await _tableImportRepository.GetAllAsync();
    }
}
