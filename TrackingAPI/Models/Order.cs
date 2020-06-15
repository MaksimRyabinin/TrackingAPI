using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrackingAPI.Utils.Validators;

namespace TrackingAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        [Required]
        [OrdersCount(ErrorMessage = "Ошибка запроса")]
        public List<OrderItem> OrderItems { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int PackstationId { get; set; }

        [Required]
        [Packstation(ErrorMessage = "Ошибка запроса")]
        public Packstation Packstation { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }

    public enum OrderStatus
    {
        Registered = 0,
        InStoke = 1,
        Courier = 2,
        InPackstation = 3,
        Done = 4
    }
}
