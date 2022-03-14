import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HrUserFormFullComponent } from './hr-userformfull.component';

describe('HrUserFormFullComponent', () => {
  let component: HrUserFormFullComponent;
  let fixture: ComponentFixture<HrUserFormFullComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HrUserFormFullComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HrUserFormFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
