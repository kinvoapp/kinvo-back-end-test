import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { PortfolioModel } from 'src/app/api/models/portfolio-models';
import { PortfolioService } from 'src/app/services/portfolio.service';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent implements OnInit {
  loading: boolean = true;
  portfolio: PortfolioModel;

  constructor(
    private portfolioService: PortfolioService,
    private snackBar: MatSnackBar,
  ) { }

  get totalInvested() : number {
    return this.portfolio.investments.map(i => i.initialValue).reduce((acc, v) => acc + v);
  }

  ngOnInit() {
    this.portfolioService.getPortfolio().subscribe(
      res => {
        this.portfolio = res;
        this.loading = false;
      },
      err => {
        this.snackBar.open("Ocorreu uma falha ao tentar obter o seu portfólio");
        this.loading = false;
      },
    );
  }

}
