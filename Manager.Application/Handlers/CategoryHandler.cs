using Manager.Application.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handlers
{
    public class CategoryHandler : ICategoryRepository
    {
        private readonly ICategoryRepository _repository;
        public CategoryHandler(ICategoryRepository repository)
        {
            this._repository = repository;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public void ValidationCategory()
        {

        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await GetAllAsync();
        }


        public async Task<List<Category>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return new Category();
            }

           
        }

        public async Task<bool> InsertAsync(Category category)
        {
            ValidationInsertCategory(category);
            return await _repository.InsertAsync(category);
        }

        private static void ValidationInsertCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException();
            if (category.CategoryName == null) throw new ArgumentNullException();
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            return await _repository.UpdateAsync(category);   
        }
    }
}
