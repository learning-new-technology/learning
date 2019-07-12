import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailresortsComponent } from './detailresorts.component';

describe('DetailresortsComponent', () => {
  let component: DetailresortsComponent;
  let fixture: ComponentFixture<DetailresortsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailresortsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailresortsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
