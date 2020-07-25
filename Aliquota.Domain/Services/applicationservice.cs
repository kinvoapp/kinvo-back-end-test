using Aliquota.Domain.Infra.Context;
using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliquota.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Services
{
    public class applicationservice : Iapplicationservice
    {
        private appcontext _appcontext;

        public applicationservice(appcontext appcontext)
        {
            _appcontext = appcontext;
        }

        public void CreateApplication(application application)
        {
            try
            {
                this.ValidateArguments(application);

                if (this.ExistApplication(application))
                    throw new ArgumentException("Aplicação já existe na carteira de investimento.");

                _appcontext.applications.Add(application);

                _appcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RescueApplication(application application)
        {
            try
            {
                var searchApplication = this.SearchApplication(application);

                if (searchApplication.dateapplication > application.daterescue)
                    throw new ArgumentException("A data de resgate não pode ser menor que a data de aplicação.");

                TimeSpan timeApplication = application.daterescue.Subtract(searchApplication.dateapplication);
                
                decimal profit = this.CalculateProfit(searchApplication, timeApplication);
                
                decimal taxIR = this.CalculateTaxIR(profit, timeApplication);

                application applicationRescueUpdate;

                applicationRescueUpdate = new application
                {
                    daterescue = application.daterescue,
                    valuegrossrescue = application.valueapplication + profit,
                    taxIRrescue = taxIR,
                    valueliquidrescue = application.valueapplication + profit - taxIR
                };

                _appcontext.applications.Add(applicationRescueUpdate);

                _appcontext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalculateProfit(application application, TimeSpan timeApplication)
        {
            try
            {
                double yield = (double)(application.productfinancial.percentageyieldyear / 100);
                double yieldDay = Math.Pow(1 + yield, 1f / 365f);
                double valueRescue = Math.Pow(yieldDay, timeApplication.TotalDays) * (double)application.valueapplication;

                return (decimal)valueRescue - application.valueapplication;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalculateTaxIR(decimal profit, TimeSpan timeApplication)
        {
            try
            {
                if (timeApplication.Days <= 365 && profit > 0)
                    return 0.225m * profit;
                else if (timeApplication.Days > 365 && timeApplication.Days <= 730 && profit > 0)
                    return 0.185m * profit;
                else if (timeApplication.Days > 730 && profit > 0)
                    return 0.15m * profit;
                else
                    return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private application SearchApplication(application searchApplication)
        {
            try
            {
                application resultApplication = _appcontext.applications
                    .Include(a => a.client)
                    .Include(a => a.productfinancial)
                    .SingleOrDefault(a => a.client.id == searchApplication.client.id && a.productfinancial.id == searchApplication.productfinancial.id);

                if (resultApplication.Equals(null))
                    throw new ArgumentNullException("A aplicação informada não encontrada.");

                return resultApplication;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool ExistApplication(application application)
        {
            try
            {
                bool applicationExist = _appcontext.applications.Any(
                    a => a.client.id == application.client.id && a.productfinancial.id == application.productfinancial.id);

                return applicationExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateArguments(application application)
        {
            try
            {
                if (application.client.Equals(null))
                    throw new ArgumentNullException("Informe o cliente.");

                if (application.productfinancial.Equals(null))
                    throw new ArgumentNullException("Informe o produto financeiro.");

                if (application.valueapplication <= 0)
                    throw new ArgumentNullException("O valor informado não pode ser igual ou menor que zero.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
