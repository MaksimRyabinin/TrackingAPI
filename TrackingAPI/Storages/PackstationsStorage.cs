using System.Collections.Generic;
using System.Linq;
using TrackingAPI.Models;

namespace TrackingAPI.Storages
{
    public class PackstationsStorage
    {
        private static PackstationsStorage packstationsStorageInst = null;
        private readonly List<Packstation> packstations = null;

        private PackstationsStorage()
        {
            packstations = new List<Packstation>()
            {
                new Packstation() { Id = 1, Number = "n1", Address = "address1", IsOpen = true },
                new Packstation() { Id = 2, Number = "n2", Address = "address2", IsOpen = false }
            };
        }

        public static PackstationsStorage GetInstance()
        {
            if (packstationsStorageInst != null)
                return packstationsStorageInst;

            packstationsStorageInst = new PackstationsStorage();
            return packstationsStorageInst;
        }

        public Packstation GetPackstation(string number)
        {
            return packstations.FirstOrDefault(x => string.Equals(x.Number, number));
        }
    }
}
