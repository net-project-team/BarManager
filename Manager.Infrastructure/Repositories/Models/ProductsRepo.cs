using Dapper;
using Manager.Domain.Models;
using Manager.Infrastructure.Repositories.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infrastructure.Repositories.Models
{
    public class ProductsRepo:IRepository<Product>
    {
        private readonly string _connection;
        public ProductsRepo()
        {
            
        }

        public async Task<bool> DeleteByIdAsync(int ProductId)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"Delete from products where product_id = @id;";
                if (await conn.ExecuteAsync(cmdText, new{id = ProductId}) > 0) return true;
                else return false;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<Product> products = new List<Product>();   
                await conn.OpenAsync();
                string cmdText = @" select product_id as ProductId,
                                    category_id as CategoryId, 
                                    product_name as ProductName,
                                    product_price as ProductPrice,
                                    product_description as ProductDescription,
                                    product_picture as ProductPicture 
                                    from products;";
                products = (await conn.QueryAsync<Product>(cmdText)).ToList();
                return products;
            }
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                Product product = new Product();
                await conn.OpenAsync();
                string cmdText = @" select product_id as ProductId,
                                    category_id as CategoryId, 
                                    product_name as ProductName,
                                    product_price as ProductPrice,
                                    product_description as ProductDescription,
                                    product_picture as ProductPicture 
                                    from products where product_id = @id;";
                product = await conn.QueryFirstOrDefaultAsync<Product>(cmdText,new {id=productId});
                return product;
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"INSERT INTO products(
	                              category_id, product_name,
                                  product_price, 
                                  product_description, 
                                  product_picture)
	                              VALUES (@CategoryId, @ProductName, 
                                  @ProductPrice, @ProductDescription, @ProductPicture);";
                if (await conn.ExecuteAsync(cmdText, product) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using(NpgsqlConnection conn=new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @" update products set 
                                    category_id=@CategoryId,
                                    product_name=@ProductName,
                                    product_price=@ProductPrice,
                                    product_description=@ProductDescription,
                                    product_picture = @ProductPicture
                                    where product_id = @ProductId;";
               if(await conn.ExecuteAsync(cmdText, product)>0) return true;
               else return false;

            }
        }
    }
}
