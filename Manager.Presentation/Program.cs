﻿using Manager.Application.Handler.Interfaces;
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
        static  void Main(string[] args)
        {

            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            var wt =  waiterHandler.GetByIdWaiterAsync(1).Result;
            Console.WriteLine(wt.WaiterName);







            Console.ReadKey();
        }




           
        
    }
}