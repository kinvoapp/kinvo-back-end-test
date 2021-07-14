import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateInvestmentCommand } from '../api/commands/create-investment-coammand';
import { InvestmentFullModel, InvestmentModel } from '../api/models/investment-models';
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

  createInvestment(command: CreateInvestmentCommand): Observable<RequestResult<InvestmentModel>> {
    return this.http.post<RequestResult<InvestmentModel>>(`${apiRoute}`, command);
  }
}
