using Aliquota.Applications.Modules;
using Aliquota.Domain.AplicacaoModule;
using Aliquota.Forms.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Aplicacoes
{
    class AplicacaoOperacoes : IRegisterable
    {
        private readonly AplicacaoApplication aplicacaoApplication;
        private readonly ProdutoApplication produtoApplication;
        private readonly AplicacaoControlTable aplicacaoTable = null;

        public AplicacaoOperacoes(AplicacaoApplication _aplicacaoApplication, ProdutoApplication _produtoApplication)
        {
            this.aplicacaoApplication = _aplicacaoApplication;
            this.produtoApplication = _produtoApplication;
            aplicacaoTable = new AplicacaoControlTable();
        }

        public void AddNovoRegistro()
        {
            AplicacaoForm tela = new(produtoApplication);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                bool result = aplicacaoApplication.AddEntidade(tela.Aplicacao);

                if (result)
                    TelaPrincipal.Instancia.AtualizaRodape($"Aplicacao: {tela.Aplicacao.Id} criado com sucesso");
                else
                    TelaPrincipal.Instancia.AtualizaRodape($"Não foi possivel realizar a aplicacao.");

                List<Aplicacao> services = aplicacaoApplication.SelecionarTodasEntidades();
                aplicacaoTable.AtualizarRegistros(services);
            }
        }

        public void ResgatarRegistro()
        {
            int id = aplicacaoTable.ObtainIdSelected();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma aplicação para resgatar", "Resgatar Aplicação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Aplicacao aplicacao = aplicacaoApplication.SelecionarEntidadePorId(id);

            if (aplicacao.DataResgate != null)
            {
                MessageBox.Show("Selecione uma aplicação que ainda não tenha sido resgatada", "Resgatar Aplicação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ResgatarForm tela = new();
            tela.Aplicacao = aplicacao;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                bool result = aplicacaoApplication.EditarEntidade(id, tela.Aplicacao);

                ObterTabela();

                if (result)
                    TelaPrincipal.Instancia.AtualizaRodape($"Aplicação: {tela.Aplicacao.Id} resgatada!!");
                else
                    TelaPrincipal.Instancia.AtualizaRodape($"Não foi possivel resgatar a aplicacação {tela.Aplicacao.Id}");
            }
        }

        public void FiltrarRegistros()
        {
            FiltroAplicacaoForm telaFiltro = new();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                string tipoAplicacao = "";
                List<Aplicacao> aplicacoes = new();
                List<Aplicacao> todasAplicacoes = aplicacaoApplication.SelecionarTodasEntidades();

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroAplicacaoEnum.TodasAplicacoes:
                        {
                            aplicacoes = todasAplicacoes;
                            tipoAplicacao = "(Todas as aplicações encontradas)";
                            break;
                        }
                    case FiltroAplicacaoEnum.AplicacoesResgatadas:
                        {
                            foreach (Aplicacao aplicacao in todasAplicacoes)
                                if (aplicacao.DataResgate != null)
                                    aplicacoes.Add(aplicacao);

                            tipoAplicacao = "resgatadas";
                            break;
                        }
                    case FiltroAplicacaoEnum.AplicacoesNaoResgatadas:
                        {
                            foreach (Aplicacao aplicacao in todasAplicacoes)
                                if (aplicacao.DataResgate == null)
                                    aplicacoes.Add(aplicacao);

                            tipoAplicacao = "não resgatadas";
                            break;
                        }

                    default:
                        break;
                }

                aplicacaoTable.AtualizarRegistros(aplicacoes);
                TelaPrincipal.Instancia.AtualizaRodape($"Visualizando {aplicacoes.Count} aplicações(s) {tipoAplicacao}");
            }
        }

        public UserControl ObterTabela()
        {
            List<Aplicacao> aplicacaos = aplicacaoApplication.SelecionarTodasEntidades();
            aplicacaoTable.AtualizarRegistros(aplicacaos);
            return aplicacaoTable;
        }
    }
}
