import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HrUserFormSeeComponent } from './hr-userform-see.component';

describe('HrUserFormSeeComponent', () => {
  let component: HrUserFormSeeComponent;
  let fixture: ComponentFixture<HrUserFormSeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HrUserFormSeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HrUserFormSeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
