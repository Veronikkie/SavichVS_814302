import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminProgLangComponent } from './admin-proglang.component';

describe('AdminProgLangComponent', () => {
  let component: AdminProgLangComponent;
  let fixture: ComponentFixture<AdminProgLangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AdminProgLangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminProgLangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
