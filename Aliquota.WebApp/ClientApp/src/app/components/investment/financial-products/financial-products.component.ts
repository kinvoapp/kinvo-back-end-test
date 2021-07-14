import { Component, OnInit } from '@angular/core';
import { FinancialProductModel } from 'src/app/api/models/financial-product-models';
import { FinancialProductService } from 'src/app/services/financial-product.service';
import { InvestmentService } from 'src/app/services/investment.service';

@Component({
  selector: 'app-financial-products',
  templateUrl: './financial-products.component.html',
  styleUrls: ['./financial-products.component.css']
})
export class FinancialProductsComponent implements OnInit {
  loading: boolean = true;
  products: FinancialProductModel[];

  constructor(
    private financialProductService: FinancialProductService,
  ) { }

  ngOnInit() {
    this.financialProductService.getProducts().subscribe(
      res => {
        this.products = res.data;
        this.loading = false;
      },
      err => this.loading = false,
    );
  }
}
