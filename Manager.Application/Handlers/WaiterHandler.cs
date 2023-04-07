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
            try
            {
                return await _repository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception ("An error occurred while inserting the waiter.", ex);
            }  
        }

        public async Task<List<Waiter>> GetAllWaitersAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all the waiters.", ex);
            }
        }

        public async Task<Waiter> GetByIdWaiterAsync(int waiterId)
        {
            try
            {
                return await _repository.GetByIdAsync(waiterId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the waiter by id.", ex);
            }
        }

        public async Task<bool> InsertWaiterAsync(Waiter waiter)
        {
            try
            {
                return await _repository.InsertAsync(waiter);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the waiter.", ex);
            }
        }

        public async Task<bool> UpdateWaiterAsync(Waiter waiter)
        {
            try
            {
                return await _repository.UpdateAsync(waiter);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the waiter.", ex);
            }
        }
    }
}
