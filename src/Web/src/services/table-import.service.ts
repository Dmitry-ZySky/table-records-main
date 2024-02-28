import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

// Custom Imports
import { TableImport } from "src/models/table-import.model";


@Injectable({
  providedIn: "root"
})

export class TableImportService {
  private url = 'https://localhost:7271/';

  constructor(private _http: HttpClient) {}

  getTableImportRecords(): Observable<TableImport[]> {
    return this._http.get<TableImport[]>(this.url + 'api/TableImport').pipe(catchError(this.handleError));
  }

  postFile(input: HTMLInputElement): Observable<any> {
    return this._http.post(this.url + 'api/TableImport/', input).pipe(catchError(this.handleError));
  }

  postBatchRecords(tableImports: TableImport[]): Observable<any> {
    return this._http.post(this.url + 'api/TableImport/batch', tableImports).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
