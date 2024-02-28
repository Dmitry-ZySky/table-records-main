import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableImportDetailsComponent } from './table-import-details.component';

describe('TableImportDetailsComponent', () => {
  let component: TableImportDetailsComponent;
  let fixture: ComponentFixture<TableImportDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableImportDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableImportDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
