using Aliquota.Domain.Core.Interfaces.Repositorys;
using Aliquota.Domain.Core.Interfaces.Services;
using Aliquota.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Services
{
   public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {
        private readonly IRepositoryProduct repositoryProduct;

        public ServiceProduct(IRepositoryProduct repositoryProduct)
            :base(repositoryProduct)
        {
            this.repositoryProduct = repositoryProduct;
        }
    }
}
