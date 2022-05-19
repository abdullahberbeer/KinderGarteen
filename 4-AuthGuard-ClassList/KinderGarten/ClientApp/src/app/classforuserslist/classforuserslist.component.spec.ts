import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassforuserslistComponent } from './classforuserslist.component';

describe('ClassforuserslistComponent', () => {
  let component: ClassforuserslistComponent;
  let fixture: ComponentFixture<ClassforuserslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassforuserslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassforuserslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
