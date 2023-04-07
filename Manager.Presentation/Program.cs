using Manager.Application.Handlers;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Manager.Infrastructure.Repositories.Models;
using Microsoft.Extensions.DependencyInjection;
namespace Manager.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICategoryRepository CategoryRepo = new CategoryRepo();
            ICategoryRepository CategoryHandler = new CategoryHandler(CategoryRepo); 
            Category category = new Category();
            CategoryHandler.InsertAsync(category);
           
            
        }
    }
}