import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CineclubListComponent } from './cineclub-list.component';

describe('CineclubListComponent', () => {
  let component: CineclubListComponent;
  let fixture: ComponentFixture<CineclubListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CineclubListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CineclubListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
