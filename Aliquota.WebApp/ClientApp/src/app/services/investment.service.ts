import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InvestmentFullModel } from '../api/models/investment-models';
import { RequestResult } from '../api/models/request-result';

const apiRoute = "/api/investments"

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {

  constructor(
    private http: HttpClient,
  ) { }

  getInvestment(id: string): Observable<RequestResult<InvestmentFullModel>> {
    return this.http.get<RequestResult<InvestmentFullModel>>(`${apiRoute}/${id}`);
  }
}
