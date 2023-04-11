using Manager.Application.Handler.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handlers
{
    public class CategoryProductHandler : ICategoryProductHandler
    {
        private readonly ICategoryProductRepository _categoryProductRepository;
        public CategoryProductHandler(ICategoryProductRepository categoryProductRepository)
        {
            _categoryProductRepository = categoryProductRepository;
        }

        public async Task<bool> DeleteCategoryProductByIdAsync(int id)
        {
            try
            {
                return await _categoryProductRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CategoryProduct>> GetAllCategoryProductAsync()
        {
            try
            {
                return await _categoryProductRepository.GetAllAsync();
            }
            catch (Exception)
            {
                return new List<CategoryProduct>();
            }
        }

        public async Task<CategoryProduct> GetByIdCategoryProductAsync(int id)
        {
            try
            {
                return await _categoryProductRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return new CategoryProduct();
            }
        }

        public async Task<bool> InsertCategoryProductAsync(CategoryProduct categoryProduct)
        {
            try
            {
                return await _categoryProductRepository.InsertAsync(categoryProduct);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategoryProductAsync(CategoryProduct categoryProduct)
        {
            try
            {
                return await _categoryProductRepository.UpdateAsync(categoryProduct);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
