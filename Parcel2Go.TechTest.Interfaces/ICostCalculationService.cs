using Parcel2Go.TestTest.Entities.Models;

namespace Parcel2Go.TechTest.Interfaces
{
    public interface ICostCalculationService
    {
        decimal ItemTotalCost(TransactionItem item, IEnumerable<Price> itemPrices);
    }
}