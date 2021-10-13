using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        IProduct _IProduct;
        public AppProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }

        public async Task Add(Product Objeto)
        {
            await _IProduct.Add(Objeto);
        }

        public async Task Delete(Product Objeto)
        {
            await _IProduct.Delete(Objeto);
        }

        public async Task<Product> GetEntityById(int Id)
        {
            return await _IProduct.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Product Objeto)
        {
            await _IProduct.Update(Objeto);
        }
    }
}
