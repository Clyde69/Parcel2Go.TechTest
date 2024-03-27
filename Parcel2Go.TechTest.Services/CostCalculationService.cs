using Parcel2Go.TechTest.Interfaces;
using Parcel2Go.TestTest.Entities.Models;

namespace Parcel2Go.TechTest.Services
{
    public class CostCalculationService : ICostCalculationService
    {
        public decimal ItemTotalCost(TransactionItem item, IEnumerable<Price> itemPrices)
        {
            itemPrices = itemPrices.OrderByDescending(o => o.Quantity);

            var remainingQty = item.Quantity;
            var value = 0m;

            itemPrices.ToList().ForEach(itemPrice =>
            {
                var applicableQty = remainingQty - (remainingQty % itemPrice.Quantity);
                remainingQty -= applicableQty;

                value += (applicableQty / itemPrice.Quantity) * itemPrice.Value;
            });

            if (remainingQty > 0)
            {
                throw new Exception(string.Format("Missing pricing for {0} unit(s).", remainingQty.ToString()));
            };

            return value;
        }
    }
}
