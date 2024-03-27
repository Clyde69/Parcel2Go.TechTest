using Parcel2Go.TestTest.Entities.Enums;
using Parcel2Go.TestTest.Entities.Models;

namespace Parcel2Go.TechTest.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Dictionary<InventoryType, InventoryPrice>> GetInventoryPricesAsync();
    }
}