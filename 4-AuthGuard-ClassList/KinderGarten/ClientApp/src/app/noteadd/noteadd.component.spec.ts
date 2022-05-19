import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteaddComponent } from './noteadd.component';

describe('NoteaddComponent', () => {
  let component: NoteaddComponent;
  let fixture: ComponentFixture<NoteaddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteaddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
