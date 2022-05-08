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
            double resgateDescontado = 0;

            foreach(var resgate in resgates)
            {
                DateTime primeiraAplicacao = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao).Where(t=>t.DataMovimentacao < resgate.DataMovimentacao).Min(v=>v.DataMovimentacao);
                DateTime ultimaAplicacao = _context.Movimentacoes.Where(t=>t.Tipo == Tipo.Aplicacao).Where(t=>t.DataMovimentacao < resgate.DataMovimentacao).Max(v=>v.DataMovimentacao);

                int periodoDias = (ultimaAplicacao - primeiraAplicacao).Days;

                if(periodoDias <= 365){

                    resgateDescontado = resgate.Valor - (resgate.Valor * 0.225);
                } 
                else if (periodoDias > 365 && periodoDias <= 720) {

                    resgateDescontado = resgate.Valor - (resgate.Valor * 0.185);
                }
                else {

                    resgateDescontado = resgate.Valor - (resgate.Valor * 0.15);
                }
                
                somaResgate += resgateDescontado;
            }

            double saldo = somaAplicacao - somaResgate;

            return saldo;
        }
    }
}