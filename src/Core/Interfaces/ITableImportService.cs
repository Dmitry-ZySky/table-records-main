using Core.Entities.TableImportAggregate;
using Core.Services.Dto;

namespace Core.Interfaces;

public interface ITableImportService
{
    Task<TableImport> CreateAsync(TableImportOperation tableImportOperation);
    Task<IEnumerable<TableImport>> BatchAsync(IEnumerable<TableImportOperation> tableImportOperations);
    Task<TableImport> GetByIdAsync(int id);
    Task<IEnumerable<TableImport>> GetAllAsync();
}
