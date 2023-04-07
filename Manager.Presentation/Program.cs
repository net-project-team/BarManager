﻿using Manager.Application.Handlers;
using Manager.Application.Interfaces;
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
            IRepository<Category> CategoryRepo = new CategoryRepo();
            IRepository<Category> CategoryHandler = new CategoryHandler(CategoryRepo);
            
        }
    }
}