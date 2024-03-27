using Parcel2Go.TestTest.Entities.Enums;
using Parcel2Go.TestTest.Entities.Models;

namespace Parcel2Go.TechTest.Interfaces
{
    public interface ICheckoutService
    {
        Transaction Transaction { get; }

        Task<decimal> GetTotalPriceAsync();
        void NewTransaction();
        void Scan(InventoryType itemType, int quantity = 1);
    }
}