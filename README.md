## Generating Code Migrations

```powershell
# run these from TableImport-records/src folder, not project folder
dotnet ef migrations add Initial -c Infrastructure.Data.TableImportRecordsContext -p Infrastructure -s API -o Data/Migrations
dotnet ef database update Initial -c Infrastructure.Data.TableImportRecordsContext -p Infrastructure -s API
```
