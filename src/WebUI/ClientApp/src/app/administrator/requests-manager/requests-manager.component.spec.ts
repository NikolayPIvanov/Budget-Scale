import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestsManagerComponent } from './requests-manager.component';

describe('RequestsManagerComponent', () => {
  let component: RequestsManagerComponent;
  let fixture: ComponentFixture<RequestsManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestsManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestsManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
