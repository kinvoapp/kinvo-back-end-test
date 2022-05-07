using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Aliquota.Infrasctructure.Context;
using System.Linq;

namespace Aliquota.Infrasctructure.Repository
{
    public class MovimentacaoRepositorio : IMovimentacaoRepository
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

        public Movimentacao ObterPorGuid(Guid guid)
        {
            try{
                var movimentacao = _context.Movimentacoes.FirstOrDefault(m => m.Identificador == guid);
                if( movimentacao == null ){
                    return null;
                }
                return movimentacao;
            }
            catch {
                throw new Exception($"Erro ao obter movimentacao com Guid = {guid}.");
            }
        }

        public Movimentacao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}