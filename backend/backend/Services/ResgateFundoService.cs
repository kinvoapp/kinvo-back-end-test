

using System;
using System.Collections.Generic;
using src.Interfaces.IServices;
using src.Models;
using src.Repositories;

namespace src.Services
{
    public class ResgateFundoService : IResgateFundoService
    {
        private readonly IResgateFundoRepository resgateFundoRepository;
        int quantidadeAnos = 0;

        ///<summary>
        /// Método construtor
        ///</summary>
        ///<param name="ResgateFundoRepository">Repositorio Resgate Fundo</param>
        public ResgateFundoService(
           IResgateFundoRepository resgateRepository)
        {
            this.resgateFundoRepository = resgateRepository;

        }

        ///<summary>
        /// Salva registro de Resgate Fundo
        ///</summary>
        ///<param name="resgate">Resgate Fundo</param>
        public bool SalvarResgateFundo(ResgateFundo resgate)
        {
            if (resgate.DataReferencia > resgate.AplicacaoFundo.DataReferencia)
            {
                resgate.ValorResgateLiquido = this.CalcularAliquota(resgate);
                if (resgate.Id == 0)
                    return this.resgateFundoRepository.AddAsync(resgate).IsCompleted;
                else
                    return this.resgateFundoRepository.UpdateAsync(resgate).IsCompleted;
            }
            else
                return false;
        }

        ///<summary>
        /// Calcular a aliquota do resgate
        ///</summary>
        ///<param name="resgate">Resgate Fundo</param>
        private float CalcularAliquota(ResgateFundo resgate)
        {
            quantidadeAnos = resgate.DataReferencia.Year - resgate.AplicacaoFundo.DataReferencia.Year;
            // A partir das  quantidade anos entre o resgate e aplicacao irá gerar um calculo do IR diferente
            if (quantidadeAnos <= 1)

                return resgate.ValorResgateLiquido - (resgate.ValorResgateLiquido * 0.225f);

            else if (quantidadeAnos > 1 && quantidadeAnos < 2)

                return resgate.ValorResgateLiquido - (resgate.ValorResgateLiquido * 0.185f);

            else if (quantidadeAnos > 2)

                return resgate.ValorResgateLiquido - (resgate.ValorResgateLiquido * 0.15f);

            else
                return resgate.ValorResgateLiquido;
        }

        ///<summary>
        /// Obter Resgate Fundo id  
        ///</summary>
        ///<param name="resgate">Resgate Fundo</param>
        public ResgateFundo ObterResgateFundo(int pId)
        {
            return this.resgateFundoRepository.FirstAsync(r =>
                r.Id == pId).Result;
        }

        ///<summary>
        /// Listar Resgate Fundo 
        ///</summary>
        ///<param name="resgate">Resgate Fundo</param>
        public List<ResgateFundo> ListarResgateFundo()
        {
            return this.resgateFundoRepository.GetAll();
        }



    }
}