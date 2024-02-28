using Core.Entities.TableImportAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class TableImportRecordsContext : DbContext
{
    #pragma warning disable CS8618

    public TableImportRecordsContext(DbContextOptions<TableImportRecordsContext> options) : base(options) { }

    public DbSet<TableImport> TableImports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableImport>(ConfigureTableImport);
    }

    private void ConfigureTableImport(EntityTypeBuilder<TableImport> builder)
    {
        builder.HasKey(p  => p.Id);

        builder.Property(p => p.RequiredStringColumn)
            .IsRequired();

        builder.Property(p => p.StringColumn)
            .IsRequired();

        builder.Property(p => p.DateColumn)
            .IsRequired();

        builder.Property(p => p.SelectColumn)
            .IsRequired();
    }
}
