import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsFlowComponent } from './news-flow.component';

describe('NewsFlowComponent', () => {
  let component: NewsFlowComponent;
  let fixture: ComponentFixture<NewsFlowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsFlowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsFlowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
