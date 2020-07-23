
#region

using System;
using System.Collections.Generic;
using Aliquota.App.Interfaces;
using Aliquota.CrossCuting;
using Aliquota.Domain;

#endregion

namespace Aliquota.App
{
    public class Servico
    {
        #region Construtor

        public Servico(Cliente cliente, TipoCliente tipo)
        {
            _cliente = cliente;
            _tipo = tipo;
            _clienteService = Factory(cliente, tipo);
        }

        #endregion

        public InformacaoFiscal ClienteRealizaResgate(decimal valorResgate, int produtoId, DateTime dataResgate)
        {
            switch (_tipo)
            {
                case TipoCliente.Comum:
                    return _clienteService.Resgatar(valorResgate, produtoId, dataResgate);
                case TipoCliente.Especial:
                    return _clienteService.Resgatar(valorResgate, produtoId, dataResgate);
                case TipoCliente.Funcionario:
                    return _clienteService.Resgatar(valorResgate, produtoId, dataResgate);
                default:
                    throw new ArgumentOutOfRangeException(nameof(_tipo), _tipo, null);
            }
        }

        public void ClienteRealizaAplicacao(List<Produto> produto)
        {
            _clienteService.Aplicar(produto);
        }

        public void ClienteRealizaAplicacao(Produto produto)
        {
            _clienteService.Aplicar(produto);
        }

        private readonly Cliente _cliente;
        private readonly TipoCliente _tipo;
        private readonly ClienteServiceTemplate _clienteService;

        private ClienteServiceTemplate Factory(Cliente cliente, TipoCliente tipo)
        {
            switch (_tipo)
            {
                case TipoCliente.Comum:
                    var c1 = new ClienteComumService(cliente);
                    return c1;
                case TipoCliente.Especial:
                    var c2 = new ClienteEspecialService(cliente);
                    return c2;
                case TipoCliente.Funcionario:
                    var c3 = new FuncionarioService(cliente);
                    return c3;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipo), tipo, null);
            }
        }
    }
}