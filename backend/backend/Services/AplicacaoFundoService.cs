

using System.Collections.Generic;
using src.Interfaces.IServices;
using src.Models;
using src.Repositories;

namespace src.Services
{
    public class AplicacaoFundoService : IAplicacaoFundoService
    {
        private readonly IAplicacaoFundoRepository aplicacaoFundoRepository;

        ///<summary>
        /// Método construtor
        ///</summary>
        ///<param name="AplicacaoFundoRepository">Repositorio Aplicacao Fundo</param>
        public AplicacaoFundoService(
           IAplicacaoFundoRepository aplicacaoFundoRepository)
        {
            this.aplicacaoFundoRepository = aplicacaoFundoRepository;

        }

        ///<summary>
        /// Salva registro de Aplicacao Fundo
        ///</summary>
        ///<param name="aplicacaoFundo">Aplicacao Fundo</param>
        public bool SalvarAplicacaoFundo(AplicacaoFundo aplicacaoFundo)
        {
            //verifica se o valor da aplicacao é positivo
            if (aplicacaoFundo.ValorAplicacao <= 0)
            {
                if (aplicacaoFundo.Id == 0)
                    return this.aplicacaoFundoRepository.AddAsync(aplicacaoFundo).IsCompleted;
                else
                    return this.aplicacaoFundoRepository.UpdateAsync(aplicacaoFundo).IsCompleted;
            }
            else
                return false;
        }

        ///<summary>
        /// Obter Aplicacao Fundo id  
        ///</summary>
        ///<param name="aplicacaoFundo">Aplicacao Fundo</param>
        public AplicacaoFundo ObterAplicacaoFundo(int pId)
        {
            return this.aplicacaoFundoRepository.FirstAsync(r =>
                r.Id == pId).Result;
        }

        ///<summary>
        /// Listar Aplicacao Fundo 
        ///</summary>
        ///<param name="aplicacaoFundo">Aplicacao Fundo</param>
        public List<AplicacaoFundo> ListarSaldoFundo()
        {
            return this.aplicacaoFundoRepository.GetAll();
        }

    }
}