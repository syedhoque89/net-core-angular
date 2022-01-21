import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadProductsComponent } from './lead-products.component';

describe('LeadProductsComponent', () => {
  let component: LeadProductsComponent;
  let fixture: ComponentFixture<LeadProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeadProductsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
