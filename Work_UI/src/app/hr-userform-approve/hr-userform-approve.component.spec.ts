import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HrUserFormApproveComponent } from './hr-userform-approve.component';

describe('HrUserFormApproveComponent', () => {
  let component: HrUserFormApproveComponent;
  let fixture: ComponentFixture<HrUserFormApproveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HrUserFormApproveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HrUserFormApproveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
