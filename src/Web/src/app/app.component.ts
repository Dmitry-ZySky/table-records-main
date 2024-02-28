import { Component, ViewChild } from "@angular/core";

// Material Imports
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

// Custom Imports
import { TableImport } from 'src/models/table-import.model';
import { TableImportService } from 'src/services/table-import.service';
import { ConvertTextService } from 'src/services/converttext.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = "TableImport Records Database";

  public uploadedTableImportRecords: TableImport[] = [];
  public toggleErrorReponseVisibilty: boolean = false;
  public toggleReponseVisibilty: boolean = false;
  public responseMessage: string = "";

  public existingTableImports!: MatTableDataSource<TableImport>;
  public displayedColumns: string[] = ['requiredStringCol', 'stringCol', 'dateCol', 'selectCol', 'id'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _tableImportService: TableImportService,
    private _convertTextService: ConvertTextService,
    public dialog: MatDialog) {

    this._tableImportService.getTableImportRecords()
      .subscribe((tableImports: TableImport[]) => {
        this.existingTableImports = new MatTableDataSource<TableImport>(tableImports);
        this.existingTableImports.paginator = this.paginator;
        this.existingTableImports.sort = this.sort;
      });
  }

  public async readFileContent(event: any) {
    const file: File = event.files[0];
    return await file.text();
  }

  public async importDataFromFile(input: HTMLInputElement) {
    let fileText = await this.readFileContent(input);

    var convertedJson = await this._convertTextService.csvToJson(fileText);

    try {
      if (convertedJson.hasOwnProperty("Error")) {
        this.toggleErrorReponseVisibilty = true;
        this.responseMessage = convertedJson["Error"].toString();
      }
      else {
        this._tableImportService.postBatchRecords(convertedJson)
          .subscribe(response => {
            this.uploadedTableImportRecords = response;
            this.toggleReponseVisibilty = true;
            this.responseMessage = "Загруженные данные";

            this._tableImportService.getTableImportRecords()
              .subscribe((tableImports: TableImport[]) => {
                this.existingTableImports = new MatTableDataSource<TableImport>(tableImports);
                this.existingTableImports.paginator = this.paginator;
                this.existingTableImports.sort = this.sort;
              });
          });
      }
    } finally {
      input.value = '';
    }
  }

  public async applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.existingTableImports.filter = filterValue.trim().toLowerCase();

    if (this.existingTableImports.paginator) {
      this.existingTableImports.paginator.firstPage();
    }
  }
}
