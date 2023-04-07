using Manager.Application.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handlers
{
    public class CategoryHandler : IRepository<Category>
    {
        private readonly IRepository<Category> _repository;
        public CategoryHandler(IRepository<Category> repository)
        {
            this._repository = repository;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertAsync(Category category)
        {
            return await _repository.InsertAsync(category);
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            return await _repository.UpdateAsync(category);   
        }
    }
}
