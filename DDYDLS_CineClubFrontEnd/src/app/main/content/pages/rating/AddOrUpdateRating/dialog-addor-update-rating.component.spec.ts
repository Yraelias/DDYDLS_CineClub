import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogAddorUpdateRatingComponent } from './dialog-addor-update-rating.component';

describe('DialogAddorUpdateRatingComponent', () => {
  let component: DialogAddorUpdateRatingComponent;
  let fixture: ComponentFixture<DialogAddorUpdateRatingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogAddorUpdateRatingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogAddorUpdateRatingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
