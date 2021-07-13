import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PortfolioModel } from '../api/models/portfolio-models';
import { RequestResult } from '../api/models/request-result';

const apiRoute = "/api/portfolio"

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {

  constructor(
    private http: HttpClient,
  ) { }

  getPortfolio(): Observable<RequestResult<PortfolioModel>> {
    return this.http.get<RequestResult<PortfolioModel>>(apiRoute);
  }
}
