using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces;
using System;

namespace Aliquota.Domain.Controllers
{
    public class portfolioinvestimentcontroller
    {
        private readonly Iapplicationservice _applicationservice;

        public portfolioinvestimentcontroller(Iapplicationservice applicationservice)
        {
            _applicationservice = applicationservice;
        }

        /// <summary>
		/// Realizar uma aplicação na carteira de investimento.
		/// </summary>
		/// <param name="client">cliente informado</param>
		/// <param name="productfinancial">produto financeiro informado</param>
		/// <param name="valueapplication">valor da aplicação informado</param>
        public void ToApply(client client, productfinancial productfinancial, decimal valueapplication)
        {
            try
            {
                application applicationToApply;

                applicationToApply = new application
                {
                    idclient = client.id,
                    client = client,
                    idproductfinancial = productfinancial.id,
                    productfinancial = productfinancial,
                    dateapplication = DateTime.Now,
                    valueapplication = valueapplication
                };

                _applicationservice.CreateApplication(applicationToApply);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
		/// Realizar resgate de uma aplicação.
		/// </summary>
		/// <param name="client">cliente informado</param>
		/// <param name="productfinancial">produto financeiro informado</param>
		/// <param name="daterescue">data de resgate informado</param>
        public void Rescue(client client, productfinancial productfinancial, DateTime daterescue)
        {
            try
            {
                application applicationRescue;

                applicationRescue = new application
                {
                    idclient = client.id,
                    client = client,
                    idproductfinancial = productfinancial.id,
                    productfinancial = productfinancial,
                    daterescue = daterescue
                };

                _applicationservice.RescueApplication(applicationRescue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
