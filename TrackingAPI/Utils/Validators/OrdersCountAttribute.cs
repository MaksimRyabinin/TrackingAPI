using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrackingAPI.Models;

namespace TrackingAPI.Utils.Validators
{
    public class OrdersCountAttribute : ValidationAttribute
    {
        public OrdersCountAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            List<OrderItem> orderItems = value as List<OrderItem>;

            if (orderItems == null)
                return false;

            if (orderItems.Count == 0 || orderItems.Count > 10)
                return false;

            return true;
        }
    }
}
