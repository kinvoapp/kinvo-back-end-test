CREATE TABLE [dbo].[Aplicacao](
	[ID] [INT] NOT NULL,
	[ProdutoFinanceiro_ID] [INT] NOT NULL,
	[Cliente_ID] [INT] NOT NULL,
	[DataAplicacao] [DATETIME] NOT NULL,
	[DataRetirada] [DATETIME] NULL,
	[Valor] DECIMAL (12, 2) NOT NULL, 
    CONSTRAINT [PK_Aplicacao] PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
 CONSTRAINT [FK_ProdutoFinanceiro_ID] FOREIGN KEY ([ProdutoFinanceiro_ID]) REFERENCES [dbo].[ProdutoFinanceiro] ([ID]),
 CONSTRAINT [FK_Cliente_ID] FOREIGN KEY ([Cliente_ID]) REFERENCES [dbo].[Cliente] ([ID])
)
GO


