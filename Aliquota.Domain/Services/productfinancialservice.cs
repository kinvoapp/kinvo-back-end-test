using Aliquota.Domain.Infra.Context;
using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliquota.Domain.Interfaces;

namespace Aliquota.Domain.Services
{
    public class productfinancialservice : Iproductfinancialservice
    {
        private appcontext _appcontext;

        public productfinancialservice(appcontext appcontext)
        {
            _appcontext = appcontext;
        }

        public void CreateProductFinancial(productfinancial productfinancial)
        {
            try
            {
                this.ValidateArguments(productfinancial.name);

                if (this.ExistProductFinancial(productfinancial))
                    throw new ArgumentException("Produto financeiro já existe no cadastro.");

                _appcontext.productfinancials.Add(productfinancial);

                _appcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public productfinancial SearchProductFinancial(productfinancial productfinancial)
        {
            try
            {
                var resultProduct = _appcontext.productfinancials.FirstOrDefault(fp => fp.name == productfinancial.name);

                if (resultProduct.Equals(null))
                    throw new ArgumentNullException("O produto financeiro informado não encontrado.");

                return resultProduct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExistProductFinancial(productfinancial productfinancial)
        {
            try
            {
                bool productFinancialExist = _appcontext.productfinancials.Any(
                    a => a.name == productfinancial.name);

                return productFinancialExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateArguments(string nameproduct)
        {
            try
            {
                if (nameproduct.Equals(null))
                    throw new ArgumentNullException("Informe o nome do produto financeiro.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
