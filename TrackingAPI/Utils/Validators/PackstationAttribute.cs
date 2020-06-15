using System.ComponentModel.DataAnnotations;
using TrackingAPI.Models;
using TrackingAPI.Storages;

namespace TrackingAPI.Utils.Validators
{
    public class PackstationAttribute : ValidationAttribute
    {
        public PackstationAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            Packstation packstation = value as Packstation;

            if (packstation == null)
                return false;

            PackstationsStorage packstationsStorageInst = PackstationsStorage.GetInstance();

            var foundPackstation = packstationsStorageInst.GetPackstation(packstation.Number);

            if (foundPackstation != null && foundPackstation.IsOpen)
                return true;

            return false;
        }
    }
}
