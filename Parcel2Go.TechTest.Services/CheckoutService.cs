using Parcel2Go.TechTest.Interfaces;
using Parcel2Go.TestTest.Entities.Enums;
using Parcel2Go.TestTest.Entities.Models;
using System.Runtime.CompilerServices;
using System.Transactions;

[assembly: InternalsVisibleTo("Parcel2Go.TechTest.ServicesTests")]
namespace Parcel2Go.TechTest.Services
{
    public class CheckoutService : ICheckoutService
    {
        internal readonly IInventoryRepository _inventoryRepository;
        internal readonly ICostCalculationService _costCalculationService;

        public TestTest.Entities.Models.Transaction Transaction { get; internal set; } = new TestTest.Entities.Models.Transaction();

        public CheckoutService(IInventoryRepository inventoryRepository, ICostCalculationService costCalculationService)
        {
            _inventoryRepository = inventoryRepository;
            _costCalculationService = costCalculationService;
        }

        public void NewTransaction()
        {
            Transaction = new TestTest.Entities.Models.Transaction();
        }

        public void Scan(InventoryType itemType, int quantity = 1)
        {
            Transaction.TransactionItems.Add(new TransactionItem(itemType, quantity));
        }

        public async Task<decimal> GetTotalPriceAsync()
        {
            var inventoryPrices = await _inventoryRepository.GetInventoryPricesAsync();
            var totalItems = Transaction.TransactionItems.GroupBy(s => s.InventoryItem)
                .Select(s => new TransactionItem(s.Key, s.ToList().Sum(q => q.Quantity)));

            return totalItems.Select(item => _costCalculationService.ItemTotalCost(item,
                inventoryPrices.Where(w => w.Key == item.InventoryItem).SelectMany(s => s.Value.Prices))).Sum();

            //  Below is the commented out expanded code.
            //  Sometime worth leaving this in so junior devs can follow what's going on.
            //var totalPrice = 0m;

            //totalItems.ToList().ForEach(item =>
            //{
            //    totalPrice += _costCalculationService.ItemTotalCost(item, inventoryPrices.Where(w => w.Key == item.InventoryItem).SelectMany(s => s.Value.Prices));
            //});

            //return totalPrice;
        }
    }
}
