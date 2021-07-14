export interface CreateInvestmentCommand {
    productId: string;
    value: number;
}

export interface RedemptInvestmentCommand {
    investmentId: string;
}