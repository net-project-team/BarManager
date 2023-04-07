using Dapper;
using Manager.Application.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;

namespace Manager.Infrastructure.Repositories.Models
{
    public class OrdersRepo : IRepository<Order>
    {
        private readonly string _connection;
        public OrdersRepo()
        {
            _connection = GetConnection.Connection();
        }

        public async Task<bool> DeleteByIdAsync(int orderId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"delete from orders where order_id = @id";
                if (await conn.ExecuteAsync(cmdText, new { id = orderId }) > 0) return true;      
                else return false;

            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<Order> orders = new List<Order>();
                await conn.OpenAsync();
                string cmdText = @"select order_id as OrderId,
                                   product_id as ProductId,
                                   waiter_id as WaiterId,
                                   order_table as OrderTable,
                                   order_date as OrderDate,
                                   is_completed as IsCompleted
                                   from orders;";
                orders = (await conn.QueryAsync<Order>(cmdText)).ToList();
                return orders;
            }
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                Order orders = new Order();
                await conn.OpenAsync();
                string cmdText = @"select order_id as OrderId,
                                   product_id as ProductId,
                                   waiter_id as WaiterId,
                                   order_table as OrderTable,
                                   order_date as OrderDate,
                                   is_completed as IsCompleted
                                   from orders where order_id = @id;";
                orders = await conn.QueryFirstOrDefaultAsync<Order>(cmdText, new { id = orderId });
                return orders;
            }
        }

        public async Task<bool> InsertAsync(Order orders)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into orders(product_id,
                                   waiter_id, order_table, order_date, is_completed)
                                   values (@ProductId, @WaiterId, @OrderTable, @OrderDate,
                                   @IsCompleted);";
                if (await conn.ExecuteAsync(cmdText, orders) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Order orders)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"update orders set 
                                   product_id = @ProductId,
                                   waiter_id = @WaiterId,
                                   order_table = @OrderTable,
                                   order_date = @OrderDate,
                                   is_completed = @IsCompleted
                                   where order_id = @OrderId,";
                if(await conn.ExecuteAsync(cmdText, orders)>0) return true;
                else return false;
            }
        }
    }
}
