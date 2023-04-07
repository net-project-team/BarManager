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
    public class WaiterHandler : IWaiterHandler
    {
        private readonly IWaiterRepository _repository;

        public WaiterHandler(IWaiterRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteWaiterByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<Waiter>> GetAllWaitersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Waiter> GetByIdWaiterAsync(int waiterId)
        {
            return await _repository.GetByIdAsync(waiterId);
        }

        public async Task<bool> InsertWaiterAsync(Waiter waiter)
        {
            return await _repository.InsertAsync(waiter);
        }

        public async Task<bool> UpdateWaiterAsync(Waiter waiter)
        {
            return await _repository.UpdateAsync(waiter);
        }
    }
}
