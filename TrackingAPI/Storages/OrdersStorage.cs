using System;
using System.Collections.Generic;
using System.Linq;
using TrackingAPI.Models;

namespace TrackingAPI.Storages
{
    public class OrdersStorage
    {
        private static OrdersStorage ordersStorageInst = null;
        private List<Order> orders = null;

        private OrdersStorage()
        {
            orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    Amount = 100,
                    CustomerId = 1,
                    Customer = new Customer() { Id = 1, PhoneNumber = "+7111-111-11-11", FIO = "fio1" },
                    PackstationId = 1,
                    Packstation = new Packstation() { Id = 1, Address = "address1", Number = "n1", IsOpen = true },
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem() {Id = 1, ProductName = "product1"},
                        new OrderItem() {Id = 2, ProductName = "product2"}
                    },
                    Status = OrderStatus.Registered
                },
                new Order()
                {
                    Id = 2,
                    Amount = 200,
                    CustomerId = 2,
                    Customer = new Customer() { Id = 2, PhoneNumber = "+7222-222-22-22", FIO = "fio2" },
                    PackstationId = 1,
                    Packstation = new Packstation() { Id = 1, Address = "address1", Number = "n1", IsOpen = true },
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem() {Id = 3, ProductName = "product3"},
                        new OrderItem() {Id = 4, ProductName = "product4"}
                    },
                    Status = OrderStatus.InStoke
                }
            };
        }

        public static OrdersStorage GetInstance()
        {
            if (ordersStorageInst != null)
                return ordersStorageInst;

            ordersStorageInst = new OrdersStorage();
            return ordersStorageInst;
        }

        public Order GetOrder(int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public Order CreateOrder(Order order)
        {
            orders.Add(order);

            return order;
        }

        public Order UpdateOrder(int id, Order order)
        {
            var foundOrder = orders.FirstOrDefault(x => x.Id == id);

            if (foundOrder == null)
                throw new ApplicationException("Заказ не найден");

            if (foundOrder.Status != order.Status)
                throw new ApplicationException("Статус заказа нельзя изменить");

            foundOrder.Amount = order.Amount;
            foundOrder.CustomerId = order.CustomerId;
            foundOrder.Customer = order.Customer;
            foundOrder.OrderItems = order.OrderItems;
            foundOrder.PackstationId = order.PackstationId;
            foundOrder.Packstation = order.Packstation;

            return foundOrder;
        }

        public Order ChangeOrderStatus(int id, OrderStatus newStatus)
        {
            var foundOrder = orders.FirstOrDefault(x => x.Id == id);

            if (foundOrder == null)
                throw new ApplicationException("Заказ не найден");

            if ((int)newStatus - (int)foundOrder.Status != 1)
                throw new ApplicationException("Нарушение цепочки изменения статуса");

            foundOrder.Status = newStatus;

            return foundOrder;
        }

        public void RemoveOrder(int id)
        {
            Order order = orders.FirstOrDefault(x => x.Id == id);

            if (order != null)
                orders.Remove(order);

            return;
        }
    }
}
