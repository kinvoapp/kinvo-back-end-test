

using System.Collections.Generic;
using kinvo.api.Interfaces.IServices;
using src.Interfaces.IServices;
using src.Models;
using src.Repositories;

namespace src.Services
{
    public class SaldoFundoService : ISaldoFundoService
    {
        private readonly ISaldoFundoRepository saldoFundoRepository;

        ///<summary>
        /// Método construtor
        ///</summary>
        ///<param name="SaldoFundoRepository">Repositorio Saldo Fundo</param>
        public SaldoFundoService(
           ISaldoFundoRepository saldoRepository)
        {
            this.saldoFundoRepository = saldoRepository;

        }

        ///<summary>
        /// Salva registro de Saldo Fundo
        ///</summary>
        ///<param name="saldo">Saldo Fundo</param>
        public bool SalvarSaldoFundo(SaldoFundo saldo)
        {
            if (saldo.Id == 0)
                return this.saldoFundoRepository.AddAsync(saldo).IsCompleted;
            else
                return this.saldoFundoRepository.UpdateAsync(saldo).IsCompleted;
        }

        ///<summary>
        /// Obter Saldo Fundo id  
        ///</summary>
        ///<param name="saldo">Saldo Fundo</param>
        public SaldoFundo ObterSaldoFundo(int pId)
        {
            return this.saldoFundoRepository.FirstAsync(r =>
                r.Id == pId).Result;
        }

        ///<summary>
        /// Listar Saldo Fundo 
        ///</summary>
        ///<param name="saldo">Saldo Fundo</param>
        public List<SaldoFundo> ListarSaldoFundo()
        {
            return this.saldoFundoRepository.GetAll();
        }
    }
}