using Aliquota.Application.DTO;
using Aliquota.Application.Interfaces;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aliquota.Application.ApplicationService
{
    public class MovimentacaoServicoApp : IMovimentacaoServicoApp
    {
        private readonly IMovimentacaoServico _servico;
        private readonly Mapper _mapper;

        public MovimentacaoServicoApp(IMovimentacaoServico servico)
        {
            _servico = servico;
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Movimentacao, MovimentacaoDTO>().ReverseMap());
                _mapper = new(config);
        }

        public String Adicionar(MovimentacaoDTO movimentacao)
        {
            try 
            {
                if(movimentacao.Tipo.ToString() == "Resgate")
                {
                    double saldo = _servico.ObterSaldo();

                    DateTime dataUltimaAplicacao = _servico.ListarTodas().Where(t=>t.Tipo.ToString() == "Aplicacao").Max(v=>v.DataMovimentacao);

                    if(movimentacao.Valor > saldo )
                    {
                        throw new ArgumentException("Saldo insuficiente");
                    }

                    if(movimentacao.DataMovimentacao < dataUltimaAplicacao)
                    {
                        throw new ArgumentException("A data do resgate deve ser maior que a data da última aplicação.");
                    }
                }

                _servico.Adicionar(_mapper.Map<MovimentacaoDTO,Movimentacao>(movimentacao));
                return "Armazenado com sucesso";
                
            } 
            catch(ArgumentException ex) 
            {
                return ex.Message;
            }
        }

        public bool Atualizar(int id, MovimentacaoDTO movimentacao)
        {
            return _servico.Atualizar(id, _mapper.Map<MovimentacaoDTO, Movimentacao>(movimentacao));
        }

        public void Dispose()
        {
            _servico.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Excluir(int id)
        {
            return _servico.Excluir(id);
        }

        public List<MovimentacaoDTO> ListarTodas()
        {
            var movimentacoes = _servico.ListarTodas();
            List<MovimentacaoDTO> movimentacoesDTO = _mapper.Map<List<Movimentacao>, List<MovimentacaoDTO>>(movimentacoes);
            return movimentacoesDTO;
        }

        public MovimentacaoDTO ObterPorId(int id)
        {
            return _mapper.Map<Movimentacao, MovimentacaoDTO>(_servico.ObterPorId(id));
        }

        public double ObterSaldo()
        {
            return _servico.ObterSaldo();
        }
    }
}