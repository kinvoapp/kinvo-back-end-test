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
    let investments = this.portfolio.investments.filter(i => i.redemptionDate == null);
    return investments.length > 0 ? investments.map(i => i.initialValue).reduce((acc, v) => acc + v) : 0;
  }

  ngOnInit() {
    this.portfolioService.getPortfolio().subscribe(
      res => {
        this.portfolio = res.data;
        this.loading = false;
      },
      err => {
        this.snackBar.open("Ocorreu uma falha ao tentar obter o seu portfólio", "Fechar");
        this.loading = false;
      },
    );
  }

}
