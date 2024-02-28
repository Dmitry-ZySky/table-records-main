import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

// Material Imports
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

// Custom Imports
import { TableImport } from 'src/models/table-import.model';

@Component({
  selector: 'app-table-import-details',
  templateUrl: './table-import-details.component.html',
  styleUrls: ['./table-import-details.component.scss']
})
export class TableImportDetailsComponent {
  public tableImportDetailsEditForm: FormGroup;

  constructor(fb: FormBuilder, public dialogRef: MatDialogRef<TableImportDetailsComponent>, @Inject(MAT_DIALOG_DATA) public tableImport: TableImport)
  {
    this.tableImportDetailsEditForm = fb.group({
      requiredStringCol: new FormControl(tableImport.requiredStringCol, [Validators.required]),
      stringCol: new FormControl(tableImport.stringCol, []),
      dateCol: new FormControl(tableImport.dateCol, [Validators.required]),
      selectCol: new FormControl(tableImport.selectCol, [Validators.required, Validators.maxLength(2)])
    });
  }
  onCancelClick(): void {
    this.dialogRef.close();
  }
}
