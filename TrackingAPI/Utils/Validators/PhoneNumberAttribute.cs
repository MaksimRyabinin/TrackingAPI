using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TrackingAPI.Utils.Validators
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public PhoneNumberAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            string phoneNumber = value as string;

            if (phoneNumber == null)
                return false;

            string pattern = @"^[+][7]\d{3}-\d{3}-\d{2}-\d{2}";
            if (Regex.IsMatch(phoneNumber, pattern))
                return true;

            return false;
        }        
    }
}
