using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aliquota.Domain
{
	public class ServicoCliente
	{
		private ContextoInvestimento _contexto;

		public ServicoCliente(ContextoInvestimento contexto)
		{
			_contexto = contexto;
		}

		public void Adicionar(string nome)
		{
			var cliente = new Cliente { Nome = nome };
			_contexto.Clientes.Add(cliente);
			_contexto.SaveChanges();
		}

		public Cliente BuscaPorNome(string nome)
		{
			var cliente = _contexto.Clientes.FirstOrDefault(c => c.Nome == nome);

			if (cliente == null)
				throw new Exception("Cliente não encontrado");

			return cliente;
		}
	}
}
