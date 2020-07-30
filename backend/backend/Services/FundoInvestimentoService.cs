using System;
using System.Collections.Generic;
using src.Interfaces.IRepositories;
using src.Interfaces.IServices;
using src.Models;
using src.Repositories;

namespace src.Services
{
    public class FundoInvestimentoService : IFundoInvestimentoService
    {
        private readonly IFundoInvestimentoRepository fundoInvestimentoRepository;

        ///<summary>
        /// Método construtor
        ///</summary>
        ///<param name="fundoInvestimentoRepository">Repositorio Fundo Investimento</param>
        public FundoInvestimentoService(
           IFundoInvestimentoRepository fundoInvestimentoRepository)
        {
            this.fundoInvestimentoRepository = fundoInvestimentoRepository;
        }

        ///<summary>
        /// Salva registro de Fundo Investimento
        ///</summary>
        ///<param name="fundoInvestimento">Fundo Investimento</param>
        public bool SalvarFundoInvestimento(FundoInvestimento fundoInvestimento)
        {
            if (fundoInvestimento.Id == 0)
                return this.fundoInvestimentoRepository.AddAsync(fundoInvestimento).IsCompleted;
            else
                return this.fundoInvestimentoRepository.UpdateAsync(fundoInvestimento).IsCompleted;
        }

        ///<summary>
        /// Obter Fundo Investimento id  
        ///</summary>
        ///<param name="fundoInvestimento">Fundo Investimento</param>
        public FundoInvestimento ObterFundoInvestimento(int pId)
        {
            return this.fundoInvestimentoRepository.FirstAsync(r =>
                r.Id == pId).Result;
        }
           
        ///<summary>
        /// Listar Fundo Investimento 
        ///</summary>
        ///<param name="fundoInvestimento">Fundo Investimento</param>
        public List<FundoInvestimento> ListarFundoInvestimento()
        {
            return this.fundoInvestimentoRepository.GetAll();
        }
    }
}