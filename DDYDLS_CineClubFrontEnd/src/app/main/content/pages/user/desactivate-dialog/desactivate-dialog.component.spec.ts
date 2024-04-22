import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesactivateDialogComponent } from './desactivate-dialog.component';

describe('DesactivateDialogComponent', () => {
  let component: DesactivateDialogComponent;
  let fixture: ComponentFixture<DesactivateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DesactivateDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DesactivateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
