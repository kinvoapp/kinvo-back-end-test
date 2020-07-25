using Aliquota.Domain.Infra.Context;
using Aliquota.Domain.Entities;
using System;
using System.Linq;
using Aliquota.Domain.Interfaces;

namespace Aliquota.Domain.Services
{
    public class clientservice : Iclientservice
    {
        private appcontext _appcontext;

        public clientservice(appcontext appcontext)
        {
            _appcontext = appcontext;
        }

        public void CreateClient(client client)
        {
            try
            {
                this.ValidateArguments(client);

                if (this.ExistClient(client))
                    throw new ArgumentException("Cliente já existe no cadastro.");

                _appcontext.clients.Add(client);

                _appcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public client SearchClient(client client)
        {
            try
            {
                var resultClient = _appcontext.clients.FirstOrDefault(c => c.cpf == client.cpf);

                if (resultClient.Equals(null))
                    throw new ArgumentNullException("O cliente informado não encontrado.");

                return resultClient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExistClient(client client)
        {
            try
            {
                bool clientExist = _appcontext.clients.Any(
                    a => a.name == client.name && a.cpf == client.cpf);

                return clientExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateArguments(client client)
        {
            try
            {
                if (client.name.Equals(null))
                    throw new ArgumentNullException("Informe o nome do cliente.");

                if (client.cpf.Equals(null))
                    throw new ArgumentNullException("Informe o CPF do cliente.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
