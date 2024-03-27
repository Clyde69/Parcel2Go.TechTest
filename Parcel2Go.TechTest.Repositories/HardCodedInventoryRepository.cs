using Parcel2Go.TechTest.Interfaces;
using Parcel2Go.TestTest.Entities.Enums;
using Parcel2Go.TestTest.Entities.Models;

namespace Parcel2Go.TechTest.Repositories
{
    public class HardCodedInventoryRepository : IInventoryRepository
    {
        public async Task<Dictionary<InventoryType, InventoryPrice>> GetInventoryPricesAsync()
        {
            return await Task.Run(() =>
            {
                var results = new List<InventoryPrice>() {
                    new InventoryPrice(InventoryType.ServiceA, new List<Price>{ new Price(1, 10), new Price(3, 25) }),
                    new InventoryPrice(InventoryType.ServiceB, new List<Price>{ new Price(1, 12), new Price(2, 20) }),
                    new InventoryPrice(InventoryType.ServiceC, new List<Price>{ new Price(1, 15) }),
                    new InventoryPrice(InventoryType.ServiceD, new List<Price>{ new Price(1, 25) }),
                    new InventoryPrice(InventoryType.ServiceF, new List<Price>{ new Price(1, 8), new Price(2, 15) })
                };

                return results.ToDictionary(s => s.Type, s => s);
            });
        }
    }
}
