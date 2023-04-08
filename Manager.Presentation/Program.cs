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
    internal class Program
    {
        static  void Main(string[] args)
        {

            //IWaiterRepository waiterRepo = new WaiterRepo();
            //IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            //Console.WriteLine("AAAAuhgh");

            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            Console.WriteLine("AAAAuhgh");

            IProductRepository productRepository = new ProductsRepo();

            var a = waiterHandler.GetByIdWaiterAsync(1).Result;
            Console.WriteLine(a.WaiterName);
            Console.WriteLine("aaa");




            //IProductRepository productRepository = new ProductsRepo();

            //var a = waiterHandler.GetByIdWaiterAsync(1).Result;
            //Console.WriteLine(a.WaiterName);

            
            RunOrders();
            Console.ReadKey();
        }

        public async static void RunOrders()
        {
            IOrdersRepository orRepo = new OrdersRepo();
            IOrdersHandler orHand = new OrdersHandler(orRepo);
            // Order or =  await orHand.GetByIdOrdersAsync(1);
            //Console.WriteLine(or);
            List<Order> orList = await orHand.GetAllOrdersAsync();


            foreach (Order or in orList)
            {
                Console.WriteLine(or);
            }

            //IRepository<Category> CategoryRepo = new CategoryRepo();
            //IRepository<Category> CategoryHandler = new CategoryHandler(CategoryRepo);



        }
    }
}