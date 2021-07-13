import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FinancialProductModel } from '../api/models/financial-product-models';
import { RequestResult } from '../api/models/request-result';

const apiRoute = "/api/products";

@Injectable({
  providedIn: 'root'
})
export class FinancialProductService {

  constructor(
    private http: HttpClient,
  ) { }

  getProducts(): Observable<RequestResult<FinancialProductModel[]>> {
    return this.http.get<RequestResult<FinancialProductModel[]>>(apiRoute);
  }
}
