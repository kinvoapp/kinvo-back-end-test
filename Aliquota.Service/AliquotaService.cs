using Aliquiota.Infra.Database;
using Aliquota.Domain;
using System;
using System.Collections.Generic;

namespace Aliquota.Service
{
    public class AliquotaService : IAliquotaService
    {
        private readonly IRepository repository;

        public AliquotaService(IRepository repository)
        {
            this.repository = repository;
        }

        public void CriarAplicacao(double valor, double rentabilidade, int userId)
        {
            Usuario usuario = repository.GetUsuario(userId);

            usuario.RegistrarAplicacao(rentabilidade, valor);

            repository.SalvarUsuario(usuario);
        }

        public void CriarUsuarioSeNaoExiste(int userId)
        {
            Usuario usuario = repository.GetUsuario(userId);

            if (usuario == null) {
                usuario = new Usuario() { Id = userId };
                repository.AdicionarUsuario(usuario);
            }
        }

        public IEnumerable<Aplicacao> ListarAplicacoes(int userId)
        {
            Usuario usuario = repository.GetUsuario(userId);
                        
            return usuario.ListarAplicacoes();
        }

        public Aplicacao ResgatarAplicacao(int aplicacaoId, int userId)
        {
            Usuario usuario = repository.GetUsuario(userId);

            usuario.ResgatarAplicacao(aplicacaoId);

            repository.SalvarUsuario(usuario);

            return usuario.Aplicacoes.Find(x => x.Id == aplicacaoId);
        }

        public Aplicacao SimularResgateAplicacao(int aplicacaoId, int userId, DateTime dataResgate)
        {
            Usuario usuario = repository.GetUsuario(userId);

            usuario.SimularResgateAplicacao(aplicacaoId, dataResgate);

            return usuario.Aplicacoes.Find(x => x.Id == aplicacaoId);
        }

    }
}
