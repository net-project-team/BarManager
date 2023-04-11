using Manager.Application.Handler.Interfaces;
using Manager.Application.Handlers;
using Manager.Application.Repository.Interfaces;
using Manager.Infrastructure.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Presentation.Tests
{
    public class WaiterOrderTest
    {
        public static void Run()
        {
            Test();
        }

        public async static void Test()
        {
            IWaiterOrderRepository waiterOrderRepository = new WaiterOrderRepo();
            IWaiterOrderHandler waiterOrdersHandler = new WaiterOrderHandlar(waiterOrderRepository);
            var ts = await waiterOrdersHandler.GetAllWaiterOrderAsync();

            foreach (var item in ts)
            {
                Console.WriteLine(item.Waiter.WaiterId);
            }
        }
    }
}
