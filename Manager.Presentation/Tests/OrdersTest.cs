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
    public class OrdersTest
    {
        public static void Run()
        {
            RunOrders();
        }

        public async static void RunOrders()
        {

            IOrdersRepository orderRepository = new OrdersRepo();
            IOrdersHandler ordersHandler = new OrdersHandler(orderRepository);
            //List<Order> orList = await ordersHandler.GetAllOrdersAsync();
            //foreach (Order or in orList)
            //{
            //    Console.WriteLine(or.OrderId);
            //}

            // readby id islamadi

            Console.WriteLine(ordersHandler.GetByIdOrdersAsync(2).Result.OrderId);


            //    isert ishladi
            //Order order = new Order();
            //order.OrderDate = DateTime.Now;
            //order.OrderTable = 12;
            //order.Waiter = await new WaiterRepo().GetByIdAsync(3);// (WaiterHandler().GetByIdWaiterAsync(1));
            //order.IsCompleted = false;
            //Console.WriteLine(  await ordersHandler.InsertOrdersAsync(order));

            ///  update ishladi
            //Order order = new Order();
            //order.OrderId = 7;
            //order.OrderDate = DateTime.Now;
            //order.OrderTable = 2;
            //order.Waiter = await new WaiterRepo().GetByIdAsync(2);// (WaiterHandler().GetByIdWaiterAsync(1));
            //order.IsCompleted = false;
            //Console.WriteLine(await ordersHandler.UpdateOrdersAsync(order));

        }
    }
}
