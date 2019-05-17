import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogConfirmRemoveComponent } from './dialog-confirm-remove.component';

describe('DialogConfirmRemoveComponent', () => {
  let component: DialogConfirmRemoveComponent;
  let fixture: ComponentFixture<DialogConfirmRemoveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogConfirmRemoveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogConfirmRemoveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
