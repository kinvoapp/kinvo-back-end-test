import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinancialProductsComponent } from './financial-products.component';

describe('FinancialProductsComponent', () => {
  let component: FinancialProductsComponent;
  let fixture: ComponentFixture<FinancialProductsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinancialProductsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinancialProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
