using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Aliquota.Infrasctructure.Context;
using System.Linq;

namespace Aliquota.Infrasctructure.Repository
{
    public class MovimentacaoRepositorio : IMovimentacaoRepositorio
    {
        private readonly AliquotaContext _context;
        public const double rentababilidadeAnual = 0.12;

        public MovimentacaoRepositorio()
        {
            _context = new AliquotaContext();
        }

        public bool Adicionar(Movimentacao movimentacao)
        {
            try {
                _context.Movimentacoes.Add(movimentacao);
                _context.SaveChanges();

                return true;
            }
            catch {
                return false;
            }
        }

        public bool Atualizar(int id, Movimentacao movimentacao)
        {
           try {
               if( id != movimentacao.Id)
               {
                   return false;
               }
               _context.Entry(movimentacao).State = EntityState.Modified;
               _context.SaveChanges();
               return true;
           }
           catch{
               return false;
           }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            var movimentacao = _context.Movimentacoes.FirstOrDefault(m => m.Id == id);

            try{
                if( movimentacao == null)
                {
                    return false;
                }
                _context.Movimentacoes.Remove(movimentacao);
                _context.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public List<Movimentacao> ListarTodas()
        {
            try {
                return _context.Movimentacoes.ToList();
            }
            catch {
                throw new Exception("Erro ao tentar listar movimentacoes");
            }
        }

        public Movimentacao ObterPorId(int id)
        {
            return _context.Movimentacoes.FirstOrDefault(m => m.Id == id);
        }

        public Double ObterSaldo()
        {
            
            double saldoAplicadoComJuros = 0;

            List<Movimentacao> aplicacoes = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao).ToList();
            List<Movimentacao> resgates = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Resgate).ToList();

            double TotalAplicado = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao).Sum(t=>t.Valor);
            DateTime dataPrimeiraAplicacao = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao).Min(t=>t.DataMovimentacao);

            foreach(var aplicacao in aplicacoes)
            {
                var diasAplicacao = (DateTime.Now - aplicacao.DataMovimentacao).Days; 
                var anosAplicacao = Math.Truncate( (double) (diasAplicacao / 365) );

                if(anosAplicacao > 1)
                {

                    saldoAplicadoComJuros = saldoAplicadoComJuros + aplicacao.Valor * Math.Pow( 1 + rentababilidadeAnual, anosAplicacao);
                   
                } else {
                    saldoAplicadoComJuros = saldoAplicadoComJuros + aplicacao.Valor;
                }
            
            }

            // **** AQUI NAO ESTOU APLICANDO A REGRA PEPS - AINDA TENTANDO ACHAR UMA SOLUÇÃO PARA ISSO ****

            double lucroTotal = saldoAplicadoComJuros - TotalAplicado;
            double saldo = saldoAplicadoComJuros;
            
            foreach(var resgate in resgates)
            {
                int diasAteResgate = (resgate.DataMovimentacao - dataPrimeiraAplicacao).Days;

                if(diasAteResgate <= 365){
                    saldo = saldo - (resgate.Valor + (lucroTotal * 0.225));
                }
                else if (diasAteResgate > 365 && diasAteResgate <= 720) {

                    saldo = saldo - (resgate.Valor + (lucroTotal * 0.185));
                   
                }
                else {

                    saldo = saldo - (resgate.Valor + (lucroTotal * 0.15));
                }
            }

            return saldo;
           
        }
    }
}