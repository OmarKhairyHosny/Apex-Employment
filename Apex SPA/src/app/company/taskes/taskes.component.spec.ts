import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskesComponent } from './taskes.component';

describe('TaskesComponent', () => {
  let component: TaskesComponent;
  let fixture: ComponentFixture<TaskesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
