using Microsoft.AspNetCore.Mvc;
using System;
using TrackingAPI.Models;
using TrackingAPI.Storages;

namespace TrackingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersStorage ordersStorageInst = null;

        public OrdersController()
        {
            ordersStorageInst = OrdersStorage.GetInstance();
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(int orderId)
        {
            var result = ordersStorageInst.GetOrder(orderId);

            if (result == null)
                return BadRequest("Заказ не найден");

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order newOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = ordersStorageInst.CreateOrder(newOrder);

            return Ok(result);
        }

        [HttpPut("{orderId}")]
        public IActionResult Update(int orderId, [FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = ordersStorageInst.UpdateOrder(orderId, order);

                return Ok(result);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpPut("status/{orderId}")]
        public IActionResult ChangeStatus(int orderId, [FromBody] int newStatus)
        {
            try
            {
                if (!Enum.IsDefined(typeof(OrderStatus), newStatus))
                    return BadRequest("Статус заказа не найден");

                var result = ordersStorageInst.ChangeOrderStatus(orderId, (OrderStatus)newStatus);

                return Ok(result);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpDelete("{orderId}")]
        public IActionResult Remove(int orderId)
        {
            ordersStorageInst.RemoveOrder(orderId);

            return Ok();
        }
    }
}
