import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HrUserFormComponent } from './hr-userform.component';

describe('HrUserFormComponent', () => {
  let component: HrUserFormComponent;
  let fixture: ComponentFixture<HrUserFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HrUserFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HrUserFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
