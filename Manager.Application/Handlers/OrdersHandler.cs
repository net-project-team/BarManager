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
    public class OrdersHandler : IOrdersHandler
    {
        private readonly IOrdersRepository _repository;
        
        public OrdersHandler(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteByIdOrdersAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order> GetByIdOrdersAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertOrdersAsync(Order entity)
        {
           return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateOrdersAsync(Order entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
