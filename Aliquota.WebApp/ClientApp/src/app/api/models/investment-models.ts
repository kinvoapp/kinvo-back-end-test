import { FinancialProductModel } from "./financial-product-models";
import { InvestmentEvaluationModel } from "./investment-evaluation-models";

export interface InvestmentModel {
    id: string;
    applicationDate: Date;
    financialProduct: FinancialProductModel;
    initialValue: number;
    redemptionDate: Date;
}

export interface InvestmentFullModel extends InvestmentModel {
    currentValue: number;
    evaluations: InvestmentEvaluationModel[];
}