using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handler.Interfaces
{
    public interface ICategoryProductHandler
    {
        public Task<List<CategoryProduct>> GetAllCategoryProductAsync();
        public Task<CategoryProduct> GetByIdCategoryProductAsync(int id);
        public Task<bool> UpdateCategoryProductAsync(CategoryProduct categoryProduct);
        public Task<bool> DeleteCategoryProductByIdAsync(int id);
        public Task<bool> InsertCategoryProductAsync(CategoryProduct categoryProduct);
    }
}
