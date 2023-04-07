﻿using Dapper;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Manager.Infrastructure.Repositories.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infrastructure.Repositories.Models
{
    public class CategoryRepo : IRepository<Category>
    {

        private readonly string _connection;
        public CategoryRepo()
        {
            _connection = GetConnection.Connection();
        }
        public async Task<bool> DeleteByIdAsync(int categoryId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"delete from categories where category_id=@id;";
                if (await conn.ExecuteAsync(cmdText, new { id = categoryId }) > 0) return true;
                else return false;
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<Category> categories = new List<Category>();
                await conn.OpenAsync();
                string cmdText = @"select category_id as CategoryId,
                                   category_name as CategoryName
                                   from categories;";
                categories = (await conn.QueryAsync<Category>(cmdText)).ToList();
                return categories;
            }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                Category categorie = new Category();
                await conn.OpenAsync();
                string cmdText = @"select category_id as CategoryId,
                                   category_name as CategoryName
                                   from categories;";
                categorie = await conn.QueryFirstOrDefaultAsync<Category>(cmdText);
                return categorie;
            }
        }

        public async Task<bool> InsertAsync(Category category)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into categories(category_name)
                                   values(@CategoryName);";
                if (await conn.ExecuteAsync(cmdText, category) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"update categories set category_name=@CategoryName;";
                if (await conn.ExecuteAsync(cmdText, category) > 0) return true;
                else return false;
            }
        }
    }
}
