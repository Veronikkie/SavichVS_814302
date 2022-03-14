import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HrUserFormRejectComponent } from './hr-userform-reject.component';

describe('HrUserFormRejectComponent', () => {
  let component: HrUserFormRejectComponent;
  let fixture: ComponentFixture<HrUserFormRejectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HrUserFormRejectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HrUserFormRejectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
