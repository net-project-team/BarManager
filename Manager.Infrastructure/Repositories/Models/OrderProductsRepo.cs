﻿using Dapper;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;

namespace Manager.Infrastructure.Repositories.Models
{
    public class OrderProductsRepo : IOrderProductRepository
    {
        private readonly string _connection;
        public OrderProductsRepo()
        {
            _connection = GetConnection.Connection();
        }


        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"delete from order_product where id = @id";
                if (await conn.ExecuteAsync(cmdText, new { id = id }) > 0) return true;
                else return false;

            }
        }

        public async Task<List<OrderProduct>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<OrderProduct> op = new List<OrderProduct>();
                await conn.OpenAsync();
                string cmdText = @"select * from order_product;";
                
                var reader = await conn.ExecuteReaderAsync(cmdText);
                while (await reader.ReadAsync())
                {
                    op.Add(new OrderProduct
                    {
                        Id = reader.GetInt32(0),
                        Order = await new OrdersRepo().GetByIdAsync(reader.GetInt32(1)),
                        Product = await new ProductsRepo().GetByIdAsync(reader.GetInt32(2))
                    });
                }
                return op;
            }
        }

        public async Task<OrderProduct> GetByIdAsync(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                OrderProduct op = new OrderProduct();
                await conn.OpenAsync();
                string cmdText = @"select * from order_product where id = @idd";
                var reader = await conn.ExecuteReaderAsync(cmdText, new { idd = id });

                while (await reader.ReadAsync())
                {
                    op.Id = reader.GetInt32(0);
                    op.Order = await new OrdersRepo().GetByIdAsync(reader.GetInt32(1));
                    op.Product = await new ProductsRepo().GetByIdAsync(reader.GetInt32(2));
                }   

                return op;

            };
        }

        public async Task<bool> InsertAsync(OrderProduct entity)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into order_product(
                                    order_id, product_id)
                                    values (@Order, @Product);";

                if (await conn.ExecuteAsync(cmdText,
                    new {
                        Order = entity.Order.OrderId,
                        Product = entity.Product.ProductId
                    }) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(OrderProduct entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"update order_product set
                                    order_id = @Order,
                                    product_id = @Product
                                    where id = @Id;";
                if (await conn.ExecuteAsync(cmdText,
                    new
                    {
                        Id = entity.Id,
                        Order = entity.Order.OrderId,
                        Product = entity.Product.ProductId
                    }) > 0) return true;

                else return false;
            }
        }
    }
}
