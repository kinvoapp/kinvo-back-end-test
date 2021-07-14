import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { FinancialProductModel } from 'src/app/api/models/financial-product-models';
import { FinancialProductService } from 'src/app/services/financial-product.service';
import { InvestmentService } from 'src/app/services/investment.service';

@Component({
  selector: 'app-financial-product-apply',
  templateUrl: './financial-product-apply.component.html',
  styleUrls: ['./financial-product-apply.component.css']
})
export class FinancialProductApplyComponent implements OnInit {
  loading: boolean = true;
  product: FinancialProductModel;

  form: FormGroup;

  constructor(
    private financialProductService: FinancialProductService,
    private investmentService: InvestmentService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private fb: FormBuilder,
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      investmentValue: [null, Validators.required]
    });

    let id = this.route.snapshot.paramMap.get("id");
    this.financialProductService.getProduct(id).subscribe(
      res => {
        if (res.success) {
          this.product = res.data;
        } else {
          this.snackBar.open(res.message, "Fechar");
        }

        this.loading = false;
      },
      err => this.loading = false,
    );
  }

  onApply() {
    this.investmentService.createInvestment({
       productId: this.product.id,
       value: this.form.value.invesmentValue,
    })
  }

}
