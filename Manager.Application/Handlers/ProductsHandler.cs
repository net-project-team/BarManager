using Manager.Application.Handler.Interfaces;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handlers
{
    public class ProductsHandler : IProductHandler
    {
        private readonly IProductRepository _repository;
        public ProductsHandler(IProductRepository repository)
        {
            this._repository = repository;
        }
        public async Task<bool> DeleteByIdProductAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetByIdProductAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertProductAsync(Product entity)
        {
           return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateProductAsync(Product entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
