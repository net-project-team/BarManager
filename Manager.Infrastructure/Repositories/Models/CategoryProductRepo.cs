using Dapper;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infrastructure.Repositories.Models
{
    public class CategoryProductRepo : ICategoryProductRepository
    {
        private readonly string _connection;    
        public CategoryProductRepo()
        {
            _connection = GetConnection.Connection();
        }


        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"delete from category_product where cat_pro_id = @id";
                if (await conn.ExecuteAsync(cmdText, new { id = id }) > 0) return true;
                else return false;

            }
        }
        //public async Task<bool> DeleteByCategoryIdAsync(int id)
        //{
        //    using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
        //    {
        //        await conn.OpenAsync();
        //        string cmdText = @"delete from ocategory_product where order_id = @id";
        //        if (await conn.ExecuteAsync(cmdText, new { id = id }) > 0) return true;
        //        else return false;

        //    }
        //}
        //public async Task<bool> DeleteByProductIdAsync(int id)
        //{
        //    using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
        //    {
        //        await conn.OpenAsync();
        //        string cmdText = @"delete from order_product where product_id = @id";
        //        if (await conn.ExecuteAsync(cmdText, new { id = id }) > 0) return true;
        //        else return false;

        //    }
        //}
        public async Task<List<CategoryProduct>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<CategoryProduct> cp = new List<CategoryProduct>();
                await conn.OpenAsync();
                string cmdText = @"select * from category_product;";

                var reader = await conn.ExecuteReaderAsync(cmdText);
                while (await reader.ReadAsync())
                {
                    cp.Add(new CategoryProduct
                    {
                        CategoryProductId = reader.GetInt32(0),
                        Category = await new CategoryRepo().GetByIdAsync(reader.GetInt32(1)),
                        Product = await new ProductsRepo().GetByIdAsync(reader.GetInt32(2))
                    });
                }
                return cp;
            }
        }

        public async Task<CategoryProduct> GetByIdAsync(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                CategoryProduct cp = new CategoryProduct();
                await conn.OpenAsync();
                string cmdText = @"select * from category_product where cat_pro_id = @idd";
                var reader = await conn.ExecuteReaderAsync(cmdText, new { idd = id });
                while (await reader.ReadAsync())
                {
                    cp.CategoryProductId = reader.GetInt32(0);
                    cp.Category = await new CategoryRepo().GetByIdAsync(reader.GetInt32(1));
                    cp.Product = await new ProductsRepo().GetByIdAsync(reader.GetInt32(2));

                }

                return cp;

            };
        }

        public async Task<bool> InsertAsync(CategoryProduct entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into category_product(
                                    category_id, product_id)
                                    values (@Order, @Product);";

                if (await conn.ExecuteAsync(cmdText,
                    new
                    {
                        Category = entity.Category.CategoryID,
                        Product = entity.Product.ProductId
                    }) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(CategoryProduct entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"update category_product set
                                    category_id = @Category,
                                    product_id = @Product
                                    where cat_pro_id = @Id;";
                if (await conn.ExecuteAsync(cmdText,
                    new
                    {
                        CategoryProductId = entity.CategoryProductId,
                        Category = entity.Category.CategoryID,
                        Product = entity.Product.ProductId
                    }) > 0) return true;

                else return false;
            }
        }
    }
}
