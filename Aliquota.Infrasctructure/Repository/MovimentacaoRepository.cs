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
            throw new NotImplementedException();
        }

        public Double ObterSaldo()
        {
            double somaAplicacao = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao).Sum(v=>v.Valor);
           

            List<Movimentacao> resgates = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Resgate).ToList();

            double somaResgate = 0;
            double somaAplicacoes = 0;
            double resgateDescontado = 0;
            double lucro = 0;

            foreach(var resgate in resgates)
            {
                DateTime primeiraAplicacao = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao && t.DataMovimentacao < resgate.DataMovimentacao).Min(v=>v.DataMovimentacao);
                DateTime ultimaAplicacao = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao && t.DataMovimentacao < resgate.DataMovimentacao).Max(v=>v.DataMovimentacao);
                somaAplicacoes =  _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao && t.DataMovimentacao >= primeiraAplicacao && t.DataMovimentacao <= ultimaAplicacao ).Sum(v=>v.Valor);

                int totalDias = (ultimaAplicacao - primeiraAplicacao).Days;

                if(totalDias <= 365){

                    lucro = somaAplicacoes * rentababilidadeAnual;
                    resgateDescontado = resgate.Valor - (lucro * 0.225);
                } 
                else if (totalDias > 365 && totalDias <= 720) {

                    lucro = somaAplicacoes * rentababilidadeAnual * 2;
                    resgateDescontado = resgate.Valor - (lucro * 0.185);
                }
                else {

                    lucro = somaAplicacoes * rentababilidadeAnual * Math.Truncate((double) totalDias / 365) ;
                    resgateDescontado = resgate.Valor - (lucro * 0.15);
                }
                
                somaResgate += resgateDescontado;
            }

            double saldo = somaAplicacao - somaResgate;

            return saldo;
        }
    }
}