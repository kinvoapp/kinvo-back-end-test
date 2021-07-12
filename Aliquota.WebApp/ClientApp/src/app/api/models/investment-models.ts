import { FinancialProductModel } from "./financial-product-models";

export interface InvestmentModel {
    applicationDate: Date;
    financialProduct: FinancialProductModel;
    initialValue: number;
}