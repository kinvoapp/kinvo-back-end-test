import { Component, OnInit } from '@angular/core';
import { PortfolioService } from 'src/app/services/portfolio.service';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent implements OnInit {

  constructor(
    private portfolioService: PortfolioService,
  ) { }

  ngOnInit() {
    this.portfolioService.getPortfolio().subscribe();
  }

}
