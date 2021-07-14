import { InvestmentModel } from "./investment-models";

export interface PortfolioModel {
    balance: number;
    investments: InvestmentModel[];
}