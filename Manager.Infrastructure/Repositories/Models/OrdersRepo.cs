using Dapper;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;

namespace Manager.Infrastructure.Repositories.Models
{
    public class OrdersRepo :IOrdersRepository
    {
        private readonly string _connection;
        public OrdersRepo()
        {
            try
            {
                _connection = GetConnection.Connection();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message+" connection yoq");
            }
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
                string cmdText = @"select * from orders;";
                var reader = await conn.ExecuteReaderAsync(cmdText);
                while (await reader.ReadAsync())
                {
                    orders.Add(new Order
                    {
                        OrderId = reader.GetInt32(0),
                        Waiter = await new WaiterRepo().GetByIdAsync(reader.GetInt32(1)),
                        OrderTable = reader.GetInt32(2),
                        OrderDate = reader.GetDateTime(3),
                        IsCompleted = reader.GetBoolean(4)
                    });
                }
              
                return orders;
            }
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                Order orders = new Order();
                await conn.OpenAsync();
                string cmdText = @"select * from orders where order_id = @id;";
                var reader = await conn.ExecuteReaderAsync(cmdText, new { id = orderId });

                orders.OrderId = reader.GetInt32(0);
                orders.Waiter = await new WaiterRepo().GetByIdAsync(reader.GetInt32(1));
                orders.OrderTable = reader.GetInt32(2);
                orders.OrderDate = reader.GetDateTime(3);
                orders.IsCompleted = reader.GetBoolean(4);

                return orders;
            }
        }

        public async Task<bool> InsertAsync(Order orders)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into orders(
                                   waiter_id, order_table, order_date, is_completed)
                                   values (@Waiter, @OrderTable, @OrderDate,
                                   @IsCompleted);";
                if (await conn.ExecuteAsync(cmdText, 
                        new {
                                Waiter = orders.Waiter.WaiterId,
                                OrderTable = orders.OrderTable,
                                OrderDate = orders.OrderDate,
                                IsCompleted = orders.IsCompleted
                        }) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Order orders)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"update orders set 
                                   waiter_id = @Waiter,
                                   order_table = @OrderTable,
                                   order_date = @OrderDate,
                                   is_completed = @IsCompleted
                                   where order_id = @OrderId,";
                if (await conn.ExecuteAsync(cmdText, 
                        new {
                                OrderId = orders.OrderId,
                                Waiter = orders.Waiter.WaiterId,
                                OrderTable = orders.OrderTable,
                                OrderDate = orders.OrderDate,
                                IsCompleted = orders.IsCompleted,
                            }) > 0) return true;
                else return false;
            }
        }
    }
}
