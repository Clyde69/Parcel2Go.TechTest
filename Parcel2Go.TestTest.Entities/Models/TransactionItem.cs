using Parcel2Go.TestTest.Entities.Enums;

namespace Parcel2Go.TestTest.Entities.Models
{
    public record TransactionItem(InventoryType InventoryItem, int Quantity)
    {
        public InventoryType InventoryItem { get; private set; } = InventoryItem;
        public int Quantity { get; private set; } = Quantity;
    }
}
