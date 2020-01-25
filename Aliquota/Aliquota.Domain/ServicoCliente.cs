using System;
using System.Collections.Generic;
using System.Text;

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


	}
}
