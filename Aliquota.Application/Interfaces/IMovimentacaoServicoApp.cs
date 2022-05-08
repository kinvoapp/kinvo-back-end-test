using System;
using Aliquota.Application.DTO;
using System.Collections.Generic;


namespace Aliquota.Application.Interfaces
{
    public interface IMovimentacaoServicoApp:IDisposable
    {
        public List<MovimentacaoDTO> ListarTodas();
        public MovimentacaoDTO ObterPorId(int id);

        public String Adicionar(MovimentacaoDTO movimentacao);

        public bool Atualizar(int id, MovimentacaoDTO movimentacao);

        public bool Excluir(int id);

    }
}