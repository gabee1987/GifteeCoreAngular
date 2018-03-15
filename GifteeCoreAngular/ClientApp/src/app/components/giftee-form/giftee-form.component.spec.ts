import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GifteeFormComponent } from './giftee-form.component';

describe('GifteeFormComponent', () => {
  let component: GifteeFormComponent;
  let fixture: ComponentFixture<GifteeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GifteeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GifteeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
