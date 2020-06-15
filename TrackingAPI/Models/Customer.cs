using System.ComponentModel.DataAnnotations;
using TrackingAPI.Utils.Validators;

namespace TrackingAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FIO { get; set; }

        [PhoneNumber(ErrorMessage = "Ошибка запроса")]
        public string PhoneNumber { get; set; }
    }
}
