import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NorrkopingNewspapersComponent } from './norrkoping-newspapers.component';

describe('NorrkopingNewspapersComponent', () => {
  let component: NorrkopingNewspapersComponent;
  let fixture: ComponentFixture<NorrkopingNewspapersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NorrkopingNewspapersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NorrkopingNewspapersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
