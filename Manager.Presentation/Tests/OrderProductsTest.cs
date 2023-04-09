﻿using Manager.Application.Handler.Interfaces;
using Manager.Application.Handlers;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Presentation.Tests
{
    public class OrderProductsTest
    {
        public static void Run()
        {
            RunOrderProduct();
        }

        public static void RunOrderProduct()
        {
            IOrderProductRepository orderProductRepository = new OrderProductsRepo();
            IOrderProductHandler orderProductHandler = new OrderProductHandler(orderProductRepository);


            //List<OrderProduct> orderProductList = await orderProductHandler.GetAllOrderProductAsync();
            //foreach (OrderProduct op in orderProductList)
            //{
            //    Console.WriteLine(op.Order.OrderId);
            //}

            //readby id islamadi

            Console.WriteLine(orderProductHandler.GetByIdOrderProductAsync(5).Result.Id);


            //    insert ishladi
            //OrderProduct orderProduct = new()
            //{
            //    Order = await new OrdersRepo().GetByIdAsync(4),
            //    Product = await new ProductsRepo().GetByIdAsync(2)
            //};
            //bool isInsert = await orderProductHandler.InsertOrderProductAsync(orderProduct);
            //Console.WriteLine(isInsert);


            //  update ishladi
            //OrderProduct orderProduct = new()
            //{
            //    Id = 10,
            //    Order = await new OrdersRepo().GetByIdAsync(4),
            //    Product = await new ProductsRepo().GetByIdAsync(5)
            //};
            //bool isUpdate = await orderProductHandler.UpdateOrderProductAsync(orderProduct);
            //Console.WriteLine(isUpdate);

            //orderProductHandler.DeleteOrderProductByIdAsync(10);

        }
    }
}