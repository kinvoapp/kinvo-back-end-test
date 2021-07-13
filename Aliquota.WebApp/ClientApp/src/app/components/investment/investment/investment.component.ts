import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { ActivatedRoute, Route } from '@angular/router';
import { InvestmentFullModel } from 'src/app/api/models/investment-models';
import { InvestmentService } from 'src/app/services/investment.service';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html',
  styleUrls: ['./investment.component.css']
})
export class InvestmentComponent implements OnInit {
  investment: InvestmentFullModel;
  loading: boolean = true;

  constructor(
    private investmentService: InvestmentService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
  ) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    this.investmentService.getInvestment(id).subscribe(
      res => {
        if(res.success) {
          this.investment = res.data;
          console.log(this.investment);
        } else {
          this.snackBar.open(res.message, "Fechar");
        }

        this.loading = false;
      },
      err => {
        this.loading = false;
      }
    );
  }

}
