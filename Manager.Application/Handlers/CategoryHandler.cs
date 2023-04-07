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
    public class CategoryHandler: ICategoryHandler
    {
        private readonly ICategoryRepository _repository;
        public CategoryHandler(ICategoryRepository repository)
        {
            this._repository = repository;
        }
        
        

        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
