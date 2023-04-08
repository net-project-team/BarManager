using Manager.Application.Handler.Interfaces;
using Manager.Application.Handlers;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Manager.Infrastructure.Repositories.Models;
using Microsoft.Extensions.DependencyInjection;
namespace Manager.Presentation
{
    public class Program
    {
        static  void Main(string[] args)
        {


            //IWaiterRepository waiterRepo = new WaiterRepo();
            //IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            //Console.WriteLine("AAAAuhgh");

            //IWaiterRepository waiterRepo = new WaiterRepo();
            //IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            //Console.WriteLine("AAAAuhgh");



            //var a = waiterHandler.GetByIdWaiterAsync(1).Result;
            //Console.WriteLine(a.WaiterName);

            ZafarsTest();
           // RunOrders();
            Console.ReadKey();
        }


        public  static async void ZafarsTest()
        {
            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            Console.WriteLine(await waiterHandler.DeleteWaiterByIdAsync(1));

        }

        public async static void RunOrders() { 
            
            IOrdersRepository orderRepository = new OrdersRepo();
            IOrdersHandler ordersHandler= new OrdersHandler(orderRepository);
            //List<Order> orList = await ordersHandler.GetAllOrdersAsync();
            //foreach (Order or in orList)
            //{
            //    Console.WriteLine(or);
            //}

            Console.WriteLine( ordersHandler.GetByIdOrdersAsync(1).Result.OrderDate);
        }


    }
}